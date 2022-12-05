namespace GWP.API.Controllers
{
    using Application.Dummies;
    using Application.Dummies.DTO;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DummiesController : ApiBaseController
    {
        private readonly IDummySerivce _dummySerivce;
        public DummiesController(IDummySerivce dummySerivce)
        {
            _dummySerivce = dummySerivce;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("auth")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Result(await _dummySerivce.GetDummiesAsync());
        }
        [HttpGet("notauth")]
        public async Task<IActionResult> GetAlldrAsync()
        {
            return Result(await _dummySerivce.GetDummiesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDummyDto addDummy)
        {
            return Result(await _dummySerivce.AddAsync(addDummy));
        }
    }
}
