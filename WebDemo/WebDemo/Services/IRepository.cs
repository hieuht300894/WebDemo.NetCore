using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Services
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        T Detail(int id);
        T Insert(T item);
        T Update(T item);
        bool Delete(int id);

        List<T> GetAllV2(string ConnectionString, string ProcName, params object[] objs);
    }
    public interface IRepositoryCollection
    {
        Repository<T> GetRepository<T>() where T : class, new();
    }
}
