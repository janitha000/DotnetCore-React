using React.Entity;
using React.Repository.Context;
using React.Repository.Generic;
using React.Repository.Interfaces;

namespace React.Repository
{
    public class UserRepository : Repositorybase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public bool isEmailUnique(string email)
        {
            var user = this.GetSingle(x => x.Email == email);
            return user == null;
        }

        public bool isUsernameUnique(string username)
        {
           var user = this.GetSingle(x=> x.Name == username);
           return user == null;
        }
    }
}