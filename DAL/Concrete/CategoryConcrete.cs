using System;
using System.Collections.Generic;
using System.Linq;
using ApiDmS.DAL.IRepository;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDmS.DAL.Concrete
{
    public class CategoryConcrete : ICategoryRepository, IDisposable
    {
        private ApplicationDbContext context;

        public CategoryConcrete(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryByID(int id)
        {
            return context.Categories.Find(id);
        }

        public void InsertCategory(Category category)
        {
            context.Categories.Add(category);
        }

        public void DeleteCategory(int categoryID)
        {
            Category category = context.Categories.Find(categoryID);
            context.Categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
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