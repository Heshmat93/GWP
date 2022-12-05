namespace Domain.Helper
{
    using System.Collections.Generic;

    public class EndpointResult
    {
        public EndpointResult() { }
        public EndpointResult(bool sucess, dynamic data = null, dynamic metaData = null, IList<string> messages = null, int? totalCount = null)
        {
            Success = sucess;
            Data = data;

            if (totalCount.HasValue)
            {
                TotalCount = totalCount.Value;
            }

            if (messages != null)
            {
                Messages = messages;
            }

            MetaData = metaData;
        }

        public EndpointResult(bool sucess, string message)
        {
            Success = sucess;

            if (!string.IsNullOrEmpty(message))
            {
                Messages = new List<string> { message };
            }
        }

        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public dynamic MetaData { set; get; }
        public IList<string> Messages { get; set; }
        public int TotalCount { get; set; }
    }
}
