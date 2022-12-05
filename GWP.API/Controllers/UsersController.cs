using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GWP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto model)
        {
            var response = await _userService.Authenticate(model.UserName, model.PassWord);
            return Result(response);
        }
    }
}
