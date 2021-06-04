using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    /// <summary>
    /// Reference to an adoptable dog from the adoption API
    /// </summary>
    public class Dog
    {
        public int DogID { get; set; }
        // ID that references a specific dog in the dog adoption API
        public int APIID { get; set; }
    }
}
