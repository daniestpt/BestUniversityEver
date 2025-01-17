﻿using System.Collections.Generic;

namespace BestUniversityEver.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        bool Save();
    }
}
