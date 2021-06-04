using System;

namespace DNHModels
{
    public class User
    {
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
