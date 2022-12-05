namespace GWPPlatform.Domain.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class UserRole : IdentityUserRole<Guid>
    {
        #region Properties



        #endregion

        #region Navigations

        public User User { get; set; }
        public Role Role { get; set; }

        #endregion

        #region Constructors
        #endregion
    }
}
