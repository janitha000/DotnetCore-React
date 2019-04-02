using System.Threading.Tasks;
using React.Entity;

namespace React.Authentication.interfaces
{
    public interface IAuthenticationService
    {
        Task Register(User user);
        string Signin(User user);
    }
}
