using ApiDmS.DAL.IRepository;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiDmS.DAL.Concrete
{
    public class PriorityConcrete : IPriorityRepository, IDisposable
    {
        private ApplicationDbContext context;

        public PriorityConcrete(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Priority> GetPriorities()
        {
            return context.Priorities.ToList();
        }

        public Priority GetPriorityByID(int id)
        {
            return context.Priorities.Find(id);
        }

        public void InsertPriority(Priority priority)
        {
            context.Priorities.Add(priority);
        }

        public void DeletePriority(int priorityID)
        {
            Priority priority = context.Priorities.Find(priorityID);
            context.Priorities.Remove(priority);
        }

        public void UpdatePriority(Priority priority)
        {
            context.Entry(priority).State = EntityState.Modified;
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