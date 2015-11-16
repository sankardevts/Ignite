using System;
using System.Collections.Generic;

namespace IGNITE.Core.Domain.User
{
    /// <summary>
    /// Represents a User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the entity first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the status message
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the last loggedIn
        /// </summary>
        public DateTime? LastLoggedIN { get; set; }

        /// <summary>
        /// Gets or sets the image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the tc_accepted date
        /// </summary>
        public DateTime? TcAcceptedDate { get; set; }

        /// <summary>
        /// Gets or sets the user type
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// Gets or sets the date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

    }
}
