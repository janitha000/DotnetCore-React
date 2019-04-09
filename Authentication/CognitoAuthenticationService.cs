using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.Extensions.Logging;
using React.Authentication.interfaces;
using React.Entity;

namespace React.Authentication
{
    public class CognitoAuthenticationService : IAuthenticationService
    {
        private readonly ILogger _logger;
        private const string _clientId = "e63r39b1umh8n55p5qhhn72t8";
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

        public CognitoAuthenticationService(ILogger<CognitoAuthenticationService> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Registering users in the AWS Cognito
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task Register(User user)
        {
            try
            {
                _logger.LogDebug("Calling AWS cognito API");
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
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error when registering with Cognito");
            }

        }

        /// <summary>
        /// Sigin to AWS Cognito and take the
        /// Accesstoken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> Signin(User user)
        {
            try
            {
                _logger.LogDebug("Calling AWS cognito API");
                var cognito = new AmazonCognitoIdentityProviderClient(_region);

                var request = new AdminInitiateAuthRequest
                {
                    UserPoolId = "us-east-1_fEiQUmfRQ",
                    ClientId = _clientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
                };

                request.AuthParameters.Add("USERNAME", "Janitha");
                request.AuthParameters.Add("PASSWORD", "janitha");

                var response = await cognito.AdminInitiateAuthAsync(request);

                return response.AuthenticationResult.IdToken;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error when sigin with Cognito");
                return null;
            }


        }
    }
}