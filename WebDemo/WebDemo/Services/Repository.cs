using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebDemo.Model;
using WebDemo.Module;
using System;
using System.Data.SqlClient;

namespace WebDemo.Services
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private zModel db;
        private DbSet<T> entity;

        public Repository(zModel db)
        {
            this.db = db;
            entity = db.Set<T>();
        }

        public bool Delete(int id)
        {
            try
            {
                T item = entity.Find(id);
                if (item == null) return false;
                entity.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public T Detail(int id)
        {
            try { return entity.Find(id); }
            catch { return null; }
        }

        public IEnumerable<T> GetAll()
        {
            try { return entity.AsEnumerable<T>(); }
            catch { return new List<T>(); }
        }

        public T Insert(T item)
        {
            try
            {
                entity.Add(item);
                db.SaveChanges();
                db.Entry(item).Reload();
                return item;
            }
            catch { return null; }
        }

        public T Update(T item)
        {
            try
            {
                var edtItem = entity.Find(item.GetInt32ByName(db.GetPrimaryKeyName<T>()));
                item.CopyValue(edtItem);
                db.SaveChanges();
                db.Entry(edtItem).Reload();
                return edtItem;
            }
            catch { return null; }
        }

        public List<T> GetAllV2(string ConnectionString, string ProcName, params object[] objs)
        {
            try
            {
                string sql = "exec " + ProcName;
                for (int i = 0; i < objs.Length; i++) { sql += " {" + i + "},"; }
                sql = sql.TrimEnd(',');
                List<T> lstResult = new List<T>(entity.FromSql(sql, objs));
                return lstResult;
            }
            catch { return new List<T>(); }
        }

    }

    public class RepositoryCollection : IRepositoryCollection
    {
        private zModel db;

        public RepositoryCollection(zModel db)
        {
            this.db = db;
        }

        public Repository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(db);
        }
    }
}
