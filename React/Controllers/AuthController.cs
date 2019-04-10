using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using React.Authentication.interfaces;
using React.Entity;
using React.Error;
using React.Repository.Interfaces;
using React.Result;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Register api to register users
        /// against AWS Cognito
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] User user)
        {
            try
            {
                logger.LogDebug($"Called register endpoint with parameters {user.Name}, {user.Email}");
                EndResult registered = await this._authService.Register(user);
                if (registered.Status)
                {
                    this._userRepository.Add(user);
                    return Ok("User Created");
                }
                else
                {
                    logger.LogWarning("User not registered");
                    return BadRequest(registered.Message);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when registering");
                return Ok(new InternalServerApiError(ex));
            }

        }

        /// <summary>
        /// Login endpoint to login 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<EndResult>> Signin([FromBody] User user)
        {
            try
            {
                logger.LogDebug($"Called to login using parameters: {user.Name}");
                EndResult result = await this._authService.Signin(user);
                if (result.Status)
                    return Ok(result.EndObject);
                else
                    return BadRequest(result.Message);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error when signin");
                return Ok(new InternalServerApiError(ex));
            }

        }
    }
}