namespace Application.Users.DTO
{
    using GWPPlatform.Domain.Identity;

    public class AuthenticateResponseDto
    {
        public User User { get; set; }
        public string AuthenticationToken { get; set; }
        public string Message { get; set; }



        public string RefreshToken { get; set; }

        public AuthenticateResponseDto(User user, string authenticationToken, string refreshToken)
        {
            User = user;
            AuthenticationToken = authenticationToken;
            RefreshToken = refreshToken;
        }
        public AuthenticateResponseDto()
        {

        }
    }
}
