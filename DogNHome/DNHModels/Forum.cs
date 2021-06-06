using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Forum
    {
        public Forum(int forumID, string topic, string description)
        {
            ForumID = forumID;
            Topic = topic;
            Description = description;
        }

        public Forum()
        { }

        public int ForumID { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        
        

        
    }
}
