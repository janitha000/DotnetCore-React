using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using React.Authentication.interfaces;
using React.Entity;

namespace React.Authentication
{
    public class CognitoAuthenticationService : IAuthenticationService
    {
        private const string _clientId = "e63r39b1umh8n55p5qhhn72t8";
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

        public async Task Register(User user)
        {
            var cognito = new AmazonCognitoIdentityProviderClient(_region);
            var request = new SignUpRequest
            {
                ClientId = _clientId,
                Password = "janitha",
                Username = "Janitha"
            };

            var emailAttribute = new AttributeType
            {
                Name = "email",
                Value = "janithat@99x.lk"
            };

            request.UserAttributes.Add(emailAttribute);
            var response = await cognito.SignUpAsync(request);
        }

        public async Task<string> Signin(User user)
        {
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
    }
}