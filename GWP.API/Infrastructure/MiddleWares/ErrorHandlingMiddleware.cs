namespace GWP.API.Infrastructure.MiddleWares
{
    using Domain.Helper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Net;
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
                _logger.LogError(ex.ToString());

                await HandledGeneralException(context, ex);

            }
        }

        private async Task HandledGeneralException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var endpointResult = new EndpointResult()
            {
                Success = false,

#if DEBUG
                Messages = new List<string> { ex.ToString() }

#else          
            
                   Messages = new List<string> {"API Down" }

#endif

            };

            context.Response.ContentType = "application/json";
            //#if DEBUG
            await context.Response.WriteAsync(SerializeObject(endpointResult));

        }

        private string SerializeObject(object obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }


    }
}

