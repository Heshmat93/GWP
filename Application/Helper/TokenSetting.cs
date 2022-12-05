namespace Application.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TokenSetting
    {
        public int TokenExpiredInMin { set; get; }
        public int RefreshTokenExpiredInMin { set; get; }
        public string Key { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public string Subject { set; get; }
    }
}
