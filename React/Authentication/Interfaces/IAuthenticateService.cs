using System.Threading.Tasks;
using React.Entity;
using React.Result;

namespace React.Authentication.interfaces
{
    public interface IAuthenticationService
    {
        Task<EndResult> Register(User user);
        Task<string> Signin(User user);
    }
}
