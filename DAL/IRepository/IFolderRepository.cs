using System;
using System.Collections.Generic;
using ApiDmS.Models;

namespace ApiDmS.DAL.IRepository
{
    public interface IFolderRepository : IDisposable
    {
        IEnumerable<Folder> GetFolders();
        Folder GetFolderByID(int folderID);
        void InsertFolder(Folder folder);
        void DeleteFolder(int folderID);
        void UpdateFolder(Folder folder);
        void Save();
         
    }
}