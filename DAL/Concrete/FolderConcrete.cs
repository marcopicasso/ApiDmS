using System;
using System.Collections.Generic;
using System.Linq;
using ApiDmS.DAL.IRepository;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDmS.DAL.Concrete
{
    public class FolderConcrete 
        {
        private ApplicationDbContext context;

        public FolderConcrete(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Folder> GetFolders()
        {
            return context.Folders.ToList();
        }

        public Folder GetFolderByID(int id)
        {
            return context.Folders.Find(id);
        }

        public void InsertFolder(Folder folder)
        {
            context.Folders.Add(folder);
        }

        public void DeleteFolder(int folderID)
        {
            Folder folder = context.Folders.Find(folderID);
            context.Folders.Remove(folder);
        }

        public void UpdateFolder(Folder folder)
        {
            context.Entry(folder).State = EntityState.Modified;
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