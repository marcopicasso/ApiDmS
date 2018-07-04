using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class accessLevelAllowed
    {
        public int accessLevelAllowedID { get; set; }
        public int accessLevel { get; set; }
        public string accessLevelAllowedName { get; set; }
        

        //relationship
        public List<Document> documents { get; set; }

        //navigation properties
        public Document Document { get; set; }
    }
}