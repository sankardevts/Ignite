using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGNITE.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="lastLoggedIn"></param>
        /// <returns></returns>
        IGNITE.Core.Domain.User.User GetUserDetails(string username,string password, DateTime lastLoggedIn);

        int UserRegistrationAndUpdation(string action, IGNITE.Core.Domain.User.User user);
    }
}
