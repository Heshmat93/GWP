namespace Application.Users
{
    using Application.Helper;
    using Application.Users.DTO;
    using CleanArchitecture.Application.Common.Models;
    using GWPPlatform.Domain.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenSetting _tokenSetting;

        public UserService(UserManager<User> userManager, IOptions<TokenSetting> tokenSetting)
        {
            _userManager = userManager;
            _tokenSetting = tokenSetting.Value;
        }

        public async Task<Result> Authenticate(string userName, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.IsActive && x.Email == userName);


            if (user == default)
                return Result.Failure(new List<string>() { "InvalidUsernameOrPassword" });


            if (!await _userManager.CheckPasswordAsync(user, password))
                return Result.Failure(new List<string>() { "InvalidUsernameOrPassword" });


            //var newRefreshToken = GenerateRefreshToken();

            //user.RefreshTokens = new List<RefreshToken>
            //{
            //    newRefreshToken
            //};

            //await _userManager.UpdateAsync(user);

            var roles = (await _userManager.GetRolesAsync(user)).ToList();
            var jwtToken = await GetToken(user, roles);

            return Result.Success( new AuthenticateResponseDto(user, jwtToken, ""));
        }
        private RefreshToken GenerateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.Now.AddMinutes(_tokenSetting.RefreshTokenExpiredInMin),
                    Created = DateTime.Now,
                };
            }
        }
        private async Task<string> GetToken(User user, List<string> roles)
        {
            var claims = await SetUserClaims(user, roles);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Key ?? string.Empty));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenData = new JwtSecurityToken(_tokenSetting.Issuer ?? string.Empty, _tokenSetting.Audience ?? string.Empty, claims, expires: DateTime.Now.AddMinutes(_tokenSetting.TokenExpiredInMin), signingCredentials: signIn);
            var token = tokenHandler.WriteToken(tokenData);
            //var tokenFinal = _securityService.EncryptPlainText(token);
            //RemoveBlackListToken(user.Id);
            return token;
        }
        private async Task<Claim[]> SetUserClaims(User user, List<string> roles)
        {
     
            var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub, _tokenSetting.Subject ?? string.Empty),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddMinutes(300).ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("ArabicName", user.NameAr),
                    new Claim("EnglishName", user.NameEn),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email ?? string.Empty)
                   };

            foreach (var role in roles)
            {
                claims.Add(
                new Claim(ClaimTypes.Role, role)
                );
            }
            return claims.ToArray();
        }
    }
}
