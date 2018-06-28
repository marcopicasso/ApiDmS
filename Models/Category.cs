using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Document> Documents { get; set; }
    }
}