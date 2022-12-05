namespace GWP.API.Controllers
{
    using CleanArchitecture.Application.Common.Models;
    using Domain.Helper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    public class ApiBaseController : ControllerBase
    {

        protected DateTime GetCurrentTime()
        {
            DateTime serverTime = DateTime.Now;

            return serverTime;
        }

        protected string CurrentToken
        {
            get
            {
                return !string.IsNullOrEmpty(HttpContext.Request.Headers[HeaderNames.Authorization]) ? HttpContext.Request.Headers[HeaderNames.Authorization].ToString() : string.Empty;
            }
        }

        protected Guid CurrentUserId
        {
            get
            {
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId") == default ? new Guid() : new Guid(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            }
        }

        #region Http Results

        protected IActionResult Result(Result result)
        {
            if (result.Succeeded)
            {
                return OkResult(result.Data);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        protected IActionResult OkResult(dynamic data, int? totalCount = null)
        {
            return Ok(new EndpointResult(
                    true,
                    data: data,
                    totalCount: totalCount));
        }



        protected IActionResult OkResult(string message, dynamic data, int? totalCount = null)
        {
            return Ok(new EndpointResult(
                    true,
                    data: data,
                    totalCount: totalCount,
                    messages: new List<string> { message }));
        }

        protected IActionResult OkResult(string message, dynamic data, bool sucess)
        {
            return Ok(new EndpointResult(
                    sucess: sucess,
                    data: data,
                    totalCount: 0,
                    messages: new List<string> { message }));
        }

        protected IActionResult OkResult(IList<string> messages, dynamic data)
        {
            return Ok(new EndpointResult(
                    true,
                    data: data,
                    messages: messages));
        }
        protected IActionResult OkResult(bool sucess, string message)
        {
            return Ok(new EndpointResult(
                    sucess: sucess,
                    messages: new List<string> { message }));
        }

        protected IActionResult NotFoundResult(string message)
        {
            return NotFound(new EndpointResult(
                    false,
                    messages: new List<string> { message }));
        }

        protected IActionResult BadRequestResult(string message)
        {
            return BadRequest(new EndpointResult(
                    false,
                    messages: new List<string> { message }));
        }

        protected IActionResult BadRequestResult(IEnumerable<string> messages)
        {
            return BadRequest(new EndpointResult(
                    false,
                    messages: messages?.ToList()));
        }


        protected IActionResult UnauthorizedResult(string message)
        {
            return Unauthorized(new EndpointResult(
                    false,
                    messages: new List<string> { message }));
        }
        #endregion



    }
}

