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

        public string Signin(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}