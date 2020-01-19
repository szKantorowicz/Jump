using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Repos
{
    public interface IRepo <T>
    {
        int Add(T entity);
        Task<int> AddAsync(T entity);
        int AddRange(IList<T> entities);
        Task<int> AddRangeAsync(IList<T> entities);
        int Save(T entities);
        Task<int> SaveAsync(T entity);
        int Delete(int ID);
        Task<int> DeleteAsync(T entity);
        T GetOne(int? id);
        Task<T> GetOneAsync(int? id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        List<T> ExcuteQuery(string sql);
        Task<List<T>> ExcuteQueryAsync(string sql);
        List<T> ExcuteQuery(string sql, object[] sqlParametrsObjects);
        Task<List<T>> ExcuteQueryAsync(string sql, object[] sqlParametrsObjects);

            
    }
}
