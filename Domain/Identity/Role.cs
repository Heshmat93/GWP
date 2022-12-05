namespace GWPPlatform.Domain.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    public class Role : IdentityRole<Guid>
    {
        #region Properties



        #endregion

        #region Navigations
        public List<UserRole> UserRoles { get; set; }

        #endregion

        #region Constructors
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
        #endregion
    }
}
