using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public AuthController(IAuthenticationService service, IUserRepository repository, ILogger<AuthController> logger)
        {
            this._authService = service;
            this._userRepository = repository;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] User user)
        {
            try
            {
                logger.LogDebug($"Called register endpoint with parameters {user.Name}, {user.Email}");
                await this._authService.Register(user);
                this._userRepository.Add(user);
                return Ok("User Created");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error when registering");
                return null;
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Signin([FromBody] User user)
        {
             string id = await this._authService.Signin(user);
             return Ok(id);
        }
    }
}