using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using React.Authentication.interfaces;
using React.Entity;

namespace React.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService service)
        {
            this._authService = service;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(User user)
        {
            await this._authService.Register(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Signin()
        {
             return Ok("Token");
        }
    }
}