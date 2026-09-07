using Microsoft.AspNetCore.Mvc;
using SaveMoney.Application.Interfaces;

namespace SaveMoney.WebAPI.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetUsers());
        }
    }
}
