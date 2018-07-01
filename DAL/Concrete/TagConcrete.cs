using System;
using System.Collections.Generic;
using System.Linq;
using ApiDmS.DAL.IRepository;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDmS.DAL.Concrete
{
    public class TagConcrete : ITagRepository, IDisposable
    {
        private ApplicationDbContext context;

        public TagConcrete(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tag> GetTags()
        {
            return context.Tags.ToList();
        }

        public Tag GetTagByID(int id)
        {
            return context.Tags.Find(id);
        }

        public void InsertTag(Tag tag)
        {
            context.Tags.Add(tag);
        }

        public void DeleteTag(int tagID)
        {
            Tag tag = context.Tags.Find(tagID);
            context.Tags.Remove(tag);
        }

        public void UpdateTag(Tag tag)
        {
            context.Entry(tag).State = EntityState.Modified;
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