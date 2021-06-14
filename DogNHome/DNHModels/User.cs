using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class User
    {
        public User(string uid)
        {
            UserID = uid;
        }
        public User()
        { }

        /// <summary>
        /// As Self Described, the User account accessing the current information
        /// </summary>
        public string UserID { get; set; }
    }
}
