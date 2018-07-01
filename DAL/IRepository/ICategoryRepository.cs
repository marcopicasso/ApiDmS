using System;
using System.Collections.Generic;
using ApiDmS.Models;

namespace ApiDmS.DAL.IRepository
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int categoryID);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryID);
        void UpdateCategory(Category category);
        void Save();
         
    }
}