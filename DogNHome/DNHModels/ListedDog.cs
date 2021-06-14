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
        public ListedDog(string dogID, int listID)
        {
            this.APIID = dogID;
            this.ListID = listID;
        }
        public ListedDog()
        {

        }

        public string APIID { get; set; }
        public int ListID { get; set; }
    }
}
