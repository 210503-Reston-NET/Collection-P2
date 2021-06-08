using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNHModels
{
    /// <summary>
    /// Joining table for Dog and List
    /// </summary>
    public class DogList
    {
        public DogList(int listID, string title, DateTime created, string userName)
        {
            this.ListID = listID;
            this.Title = title;
            this.Created = created;
            this.UserName = userName;
        }
        public DogList()
        {

        }
        public int ListID { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }
    }
    
}
