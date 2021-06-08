using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Tags
    {
        public Tags(int tagID, string description)
        {
            TagID = tagID;
            Description = description;
        }

        public Tags()
        {

        }

        public int TagID { get; set; }
        public string Description { get; set; }
    }
}
