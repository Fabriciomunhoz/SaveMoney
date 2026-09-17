using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveMoney.Application.Interfaces;
using SaveMoney.Domain.Account;
using SaveMoney.Domain.Entities;
using SaveMoney.WebAPI.Models;

namespace SaveMoney.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IApplicationUserService _applicationUserService;
        public UserController(IAuthenticate authentication, IApplicationUserService applicationUserService)
        {
            _authentication = authentication;
            _applicationUserService = applicationUserService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody]LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _authentication.Authenticate(login.Email, login.Password);
                var token = await _authentication.GenerateToken(login.Email);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterDTO register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _applicationUserService.RegisterUser(register.Email, register.Password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
