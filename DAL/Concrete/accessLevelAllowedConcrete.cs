using System;
using System.Collections.Generic;
using System.Linq;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDmS.DAL.Concrete
{
    public class accessLevelAllowedConcrete
    {
         private ApplicationDbContext context;

        public accessLevelAllowedConcrete(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<accessLevelAllowed> GetAccessLevels()
        {
            return context.accessLevelAlloweds.ToList();
        }

        public accessLevelAllowed GetAccesslevelByID(int id)
        {
            return context.accessLevelAlloweds.Find(id);
        }

        public void InsertAccessLevel(accessLevelAllowed accessLevelAllowed)
        {
            context.accessLevelAlloweds.Add(accessLevelAllowed);
        }

        public void DeleteAccessLevel(int accessLevelAllowedID)
        {
            accessLevelAllowed accessLevelAllowed = context.accessLevelAlloweds.Find(accessLevelAllowedID);
            context.accessLevelAlloweds.Remove(accessLevelAllowed);
        }

        public void UpdateAccessLevel(accessLevelAllowed accessLevelAllowed)
        {
            context.Entry(accessLevelAllowed).State = EntityState.Modified;
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