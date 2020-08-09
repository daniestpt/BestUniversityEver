using BestUniversityEver.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BestUniversityEver.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BestUniversityEverContext db = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this.db = new BestUniversityEverContext();
            table = db.Set<T>();
        }
        public Repository(BestUniversityEverContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            try
            {
                return table.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T SelectByID(object id)
        {
            try
            {
                return table.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(T obj)
        {
            try
            {
                table.Add(obj);
                db.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                ((IObjectContextAdapter)db).ObjectContext.Refresh(RefreshMode.ClientWins, db.Teacher);
                ((IObjectContextAdapter)db).ObjectContext.Refresh(RefreshMode.ClientWins, db.Subject);
                ((IObjectContextAdapter)db).ObjectContext.Refresh(RefreshMode.ClientWins, db.Enrollment);
                db.SaveChanges();
            }
            return true;
        }
    }
}