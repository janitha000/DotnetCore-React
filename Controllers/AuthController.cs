using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using React.Authentication.interfaces;
using React.Entity;
using React.Repository.Interfaces;

namespace React.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthenticationService _authService;
        private IUserRepository _userRepository;

        public AuthController(IAuthenticationService service, IUserRepository repository)
        {
            this._authService = service;
            this._userRepository = repository;
        }

        [HttpPost("test")]
        public async Task<ActionResult<string>> Register(string user)
        {
            return Ok(user);
        }


        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] User user)
        {
            await this._authService.Register(user);
            this._userRepository.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Signin([FromBody] User user)
        {
             string id = await this._authService.Signin(user);
             return Ok(id);
        }
    }
}