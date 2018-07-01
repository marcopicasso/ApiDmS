using System;
using System.Collections.Generic;
using ApiDmS.Models;

namespace ApiDmS.DAL.IRepository
{
    public interface ITagRepository : IDisposable
    {
        IEnumerable<Tag> GetTags();
        Tag GetTagByID(int tagID);
        void InsertTag(Tag tag);
        void DeleteTag(int tagID);
        void UpdateTag(Tag tag);
        void Save();
    }
}