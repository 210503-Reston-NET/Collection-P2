using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNHREST.DTO
{
    public class SomeDogs
    {
        public string[] dogs { get; set; }
        public SomeDogs(string[] passedDogs)
        {
            this.dogs = passedDogs;
        }
    }
}
