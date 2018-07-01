using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class Tag
    {
        public int TagiD { get; set; }
        public string tagName { get; set; }
        

        //relationship
        public List<Document> documents { get; set; }

        //navigation properties
        public Document Document { get; set; }
    }
}