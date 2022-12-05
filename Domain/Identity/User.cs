namespace GWPPlatform.Domain.Identity
{
    using Domain.Enums;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>
    {

        #region Properties
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Gender Gender { get; set; }
        public string MobileNo { get; set; }
        public string ProfilePicture { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime BirthDate { get; set; }

        #endregion

        #region Navigations
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<UserRole> UserRoles { get; set; }
        #endregion
    }

}
