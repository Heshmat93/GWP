namespace GWPPlatform.Domain.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
