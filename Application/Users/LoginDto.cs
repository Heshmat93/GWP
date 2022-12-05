namespace Application.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class LoginDto
    {
        [Required( ErrorMessageResourceName = "FeildIsRequired")]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceName = "FeildIsRequired")]
        public string PassWord { get; set; }
    }
}
