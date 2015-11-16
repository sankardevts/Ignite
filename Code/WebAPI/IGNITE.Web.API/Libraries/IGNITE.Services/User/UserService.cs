using IGNITE.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGNITE.Services.User
{
    public class UserService : IUserService
    {
        private readonly IDbContext context;

        public UserService(IDbContext _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="lastLoggedIn"></param>
        /// <returns></returns>
        public IGNITE.Core.Domain.User.User GetUserDetails(string username, string password,DateTime lastLoggedIn)
        {
            var result = context.ExecuteFunction<IGNITE.Core.Domain.User.User>("sp_HickGetUserForLogin",
            new SqlParameter() { ParameterName = "@username", Value = username, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@password", Value = password, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@lastLoggedIn", Value = lastLoggedIn, DbType = System.Data.DbType.DateTime});
            var user = result.FirstOrDefault();
            if (user == null)
            {
                return new IGNITE.Core.Domain.User.User();
            }

            return user;
        }

        public int UserRegistrationAndUpdation(string action,IGNITE.Core.Domain.User.User user)
        {
            var sqlParams = new SqlParameter[] {
            new SqlParameter() { ParameterName = "@action", Value = action, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@id", Value = user.Id, DbType = System.Data.DbType.Int32 },
            new SqlParameter() { ParameterName = "@userName", Value = user.Username, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@password", Value = user.Password, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@firstName", Value = user.FirstName, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@lastName", Value = user.LastName, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@phoneNumber", Value = user.PhoneNumber, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@userType", Value = user.UserType, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@dateOfBirth", Value = user.DateOfBirth, DbType = System.Data.DbType.DateTime },
            new SqlParameter() { ParameterName = "@lastLoggedIn", Value = user.LastLoggedIN, DbType = System.Data.DbType.DateTime },
            new SqlParameter() { ParameterName = "@image", Value = user.Image, DbType = System.Data.DbType.String },
            new SqlParameter() { ParameterName = "@userId", Value = 0, DbType = System.Data.DbType.Int32,Direction= System.Data.ParameterDirection.Output} };
            var result = context.ExecuteFunction<int>("sp_HickUserRegistrationAndUpdation", sqlParams);
               return Convert.ToInt32(sqlParams[11].Value);
        }
    }
}
