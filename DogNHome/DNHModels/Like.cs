using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Like
    {
        public Like(string userName, int dogID)
        {
            UserName = userName;
            DogID = dogID;
        }
        public Like()
        { }

        public string UserName { get; set; }
        public int DogID { get; set; }
        
    }
}
