using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
                
        //relationship
        public List<Document> documents { get; set; }

        //navigation properties
        public Document Document { get; set; }
    }
}