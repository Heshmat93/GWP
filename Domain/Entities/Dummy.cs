namespace Domain.Dummy
{
    using GWPPlatform.Domain.Common;
    public class Dummy : BaseEntity<int>
    {
        public string RefrenceKey { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;


    }
}
