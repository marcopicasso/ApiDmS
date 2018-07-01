using System;
using System.Collections.Generic;
using ApiDmS.Models;

namespace ApiDmS.DAL.IRepository
{
    public interface IPriorityRepository : IDisposable
    {
        IEnumerable<Priority> GetPriorities();
        Priority GetPriorityByID(int priorityID);
        void InsertPriority(Priority priority);
        void DeletePriority(int priorityID);
        void UpdatePriority(Priority priority);
        void Save();
    }
}