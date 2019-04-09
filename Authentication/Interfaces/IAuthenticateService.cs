using System.Threading.Tasks;
using React.Entity;

namespace React.Authentication.interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Register(User user);
        Task<string> Signin(User user);
    }
}
