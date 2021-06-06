using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class User
    {
        public User(string userName, string password, string firstName, string lastName, string address)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
        public User()
        { }

        /// <summary>
        /// As Self Described, the User account accessing the current information
        /// </summary>
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
