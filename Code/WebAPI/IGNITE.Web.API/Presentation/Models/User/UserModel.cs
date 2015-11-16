using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGNITE.Web.API.Models.User
{
    public class UserModel
    {
        public UserModel()
        {
            // TODO: Complete member initialization
        }
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Status { get; set; }

        public string StatusMessage { get; set; }

        public DateTime? LastLoggedIN { get; set; }

        public string Image { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? TcAcceptedDate { get; set; }

        public string UserType { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}