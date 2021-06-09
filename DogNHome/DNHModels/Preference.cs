using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Preference
    {
        public Preference(string userName, int tagID)
        {
            this.UserName = userName;
            this.TagID = tagID;
        }

        public Preference()
        {

        }

        public string UserName { get; set; }
        public int TagID { get; set; }
    }
}
