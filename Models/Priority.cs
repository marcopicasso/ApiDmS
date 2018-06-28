using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class Priority
    {
        public int priorityID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Document> Documents { get; set; }
    }
}