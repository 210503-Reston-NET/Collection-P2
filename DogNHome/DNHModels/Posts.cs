﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Posts
    {
        public int PostID { get; set; }
        public string Topic { get; set; }
        public string UserCreator { get; set; }
        public int ForumID { get; set; }
    }
}