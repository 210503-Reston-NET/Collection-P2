using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    public class Alert
    {
        public Alert() { }
        public int AlertID { get; set; }
        public string UserID { get; set; }
        public string AlertType { get; set; }
        public string AlertValue { get; set; }
        public string DogID { get; set; }
    }
}
