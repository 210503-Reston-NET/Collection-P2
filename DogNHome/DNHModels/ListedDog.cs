using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    /// <summary>
    /// A List of dogs created and related by the user
    /// </summary>
    public class ListedDog
    {
        public ListedDog(int dogID, int listID)
        {
            DogID = dogID;
            ListID = listID;
        }
        public ListedDog()
        {

        }

        public int DogID { get; set; }
        public int ListID { get; set; }
    }
}
