using System.Collections.Generic;

namespace ApiDmS.Models
{
    public class Folder
    {
        public int folderID { get; set; }
        public string name { get; set; }
        public string path { get; set; }

        //relationship
        public List<Document> documents { get; set; }

        //navigation properties
        public Document Document { get; set; }

    }
}