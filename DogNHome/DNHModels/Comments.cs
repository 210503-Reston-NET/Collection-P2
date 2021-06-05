using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Comments
    {
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }
    }
}
