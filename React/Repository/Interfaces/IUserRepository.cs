using React.Entity;
using React.Repository.Generic;

namespace React.Repository.Interfaces
{
    public interface IUserRepository : IRepositryBase<User>
    {
        bool isUsernameUnique(string username);
        bool isEmailUnique(string email);
    }

}