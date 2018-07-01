using System;
using System.Collections.Generic;
using ApiDmS.Models;

namespace ApiDmS.DAL.IRepository
{
    public interface IaccessLevelAllowed : IDisposable
    {
        IEnumerable<accessLevelAllowed> GetAccessLevels();
        accessLevelAllowed GetAccesslevelByID(int accessLevelAllowedID);
        void InsertAccessLevel(accessLevelAllowed accessLevelAllowed);
        void DeleteAccessLevel(int accessLevelAllowedID);
        void UpdateAccessLevel(accessLevelAllowed accessLevelAllowed);
        void Save();
         
    }
}