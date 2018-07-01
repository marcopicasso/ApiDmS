using System;
using System.Collections.Generic;
using ApiDmS.Models;

namespace ApiDmS.DAL.IRepository
{
    public interface IDocumentRepository : IDisposable
    {
        IEnumerable<Document> GetDocuments();
        Document GetDocumentByID(int documentID);
        void InsertDocument(Document document);
        void DeleteDocument(int documentID);
        void UpdateDocument(Document document);
        void Save();
         
    }
}