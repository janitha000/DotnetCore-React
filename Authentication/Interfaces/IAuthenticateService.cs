using System.Threading.Tasks;
using React.Entity;

namespace React.Authentication.interfaces
{
    public interface IAuthenticationService
    {
        Task Register(User user);
        Task<string> Signin(User user);
    }
}
