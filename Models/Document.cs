using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiDmS.Models
{
    public class Document 
    {
        public int documentID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime uploadDate { get; set; }
        public string path { get; set; }
        public bool active { get; set; }
        public string userCreate { get; set; }
        public IFormFile FileToUpload { get; set; }


        // relationship
        public int folderID { get; set; }
        public List<accessLevelAllowed> accessLevelAlloweds { get; set; }
        public List<Tag> Tags { get; set; }
        public int categoryID { get; set; }


        //Navigation properties
        public Folder Folder { get; set; }
        public accessLevelAllowed accessLevelAllowed { get; set; }
        public Tag Tag { get; set; }
        public Category Category { get; set; }
    }
}