using System;

namespace ApiDmS.Models
{
    public class Document
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime uploadDate { get; set; }
        public long path { get; set; }
        public bool active { get; set; }
        public string userCreat { get; set; }

        public int accessLevelAllowedID { get; set; }
        public int[] tagId { get; set; }
        public int bankID { get; set; }

        public virtual accessLevelAllowed accessLevelAllowed { get; set; }
        public virtual Tag tag { get; set; }
        public virtual Bank bank { get; set; }
    }
}