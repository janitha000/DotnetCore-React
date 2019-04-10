using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.Extensions.Logging;
using React.Authentication.interfaces;
using React.Entity;
using React.Helpers;
using React.Result;

namespace React.Authentication
{
    public class CognitoAuthenticationService : IAuthenticationService
    {
        private readonly ILogger logger;
        private readonly IUserServiceHelper userServiceHelper; 
        private const string _clientId = "e63r39b1umh8n55p5qhhn72t8";
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

        public CognitoAuthenticationService(ILogger<CognitoAuthenticationService> logger, IUserServiceHelper helper)
        {
            this.logger = logger;
            this.userServiceHelper = helper;
        }

        /// <summary>
        /// Registering users in the AWS Cognito
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<EndResult> Register(User user)
        {
            try
            {
                bool isUnique = CheckUnique(user);

                if(isUnique)
                {
                    logger.LogWarning("Username or email is unique");
                    EndResult result = new EndResult
                    {
                        Status = false,
                        Message = "Username or email is not unique"
                    };
                    return result;
                }

                logger.LogDebug("Calling AWS cognito API");
                var cognito = new AmazonCognitoIdentityProviderClient(_region);
                var request = new SignUpRequest
                {
                    ClientId = _clientId,
                    Password = user.Password,
                    Username = user.Name
                };

                var emailAttribute = new AttributeType
                {
                    Name = "email",
                    Value = user.Email
                };

                request.UserAttributes.Add(emailAttribute);
                var response = await cognito.SignUpAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return new EndResult() { Status = true };      
                else
                    return new EndResult() { Status = false, Message = "User registration unsuccessful" };
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error when registering with Cognito");
                return new EndResult() { Status = false, Message = $"{ex.Message} , {ex.InnerException.Message}" };
            }

        }

        /// <summary>
        /// Sigin to AWS Cognito and take the
        /// Accesstoken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<EndResult> Signin(User user)
        {
            try
            {
                logger.LogDebug("Calling AWS cognito API");
                var cognito = new AmazonCognitoIdentityProviderClient(_region);

                var request = new AdminInitiateAuthRequest
                {
                    UserPoolId = "us-east-1_fEiQUmfRQ",
                    ClientId = _clientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
                };

                request.AuthParameters.Add("USERNAME", user.Name);
                request.AuthParameters.Add("PASSWORD", user.Password);

                var response = await cognito.AdminInitiateAuthAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new EndResult() { Status = true, EndObject = response.AuthenticationResult.IdToken };
                }
                else
                {
                    logger.LogWarning("Login failed");
                    return new EndResult() { Status = false, Message = "Login failed" };
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when sigin with Cognito");
                return new EndResult() { Status = false, Message = $"Login failed: {ex.Message} , {ex.InnerException.Message}" };
            }

        }

        public bool CheckUnique(User user)
        {
            bool isNameUnique = userServiceHelper.IsUniqueName(user.Name);
            bool isEmailUnique = userServiceHelper.IsUniqueEmail(user.Email);

            return (!isNameUnique || !isEmailUnique);
        }


    }
}