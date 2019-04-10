using React.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.Helpers
{
    public class UserServiceHelper : IUserServiceHelper
    {
        private IUserRepository repository;

        public UserServiceHelper(IUserRepository repo)
        {
            this.repository = repo;
        }

        public bool IsUniqueEmail(string email)
        {
            return repository.isEmailUnique(email);
        }

        public bool IsUniqueName(string name)
        {
            return repository.isUsernameUnique(name);
        }


    }
}
