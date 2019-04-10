using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.Helpers
{
    public interface IUserServiceHelper
    {
        bool IsUniqueName(string name);
        bool IsUniqueEmail(string email);
    }
}
