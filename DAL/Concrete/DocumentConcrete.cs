using System;
using System.Collections.Generic;
using System.Linq;
using ApiDmS.DAL.IRepository;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDmS.DAL.Concrete
{
    public class DocumentConcrete : IDocumentRepository, IDisposable
    {
        private ApplicationDbContext context;

        public DocumentConcrete(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Document> GetDocuments()
        {
            return context.Documents.ToList();
        }

        public Document GetDocumentByID(int id)
        {
            return context.Documents.Find(id);
        }

        public void InsertDocument(Document document)
        {
            context.Documents.Add(document);
        }

        public void DeleteDocument(int documentID)
        {
            Document document = context.Documents.Find(documentID);
            context.Documents.Remove(document);
        }

        public void UpdateDocument(Document document)
        {
            context.Entry(document).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}