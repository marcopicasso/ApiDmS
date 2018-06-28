using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class Tag
    {
        public int TagiD { get; set; }
        public string tagName { get; set; }
        public List<Document> Documents { get; set; }
    }
}