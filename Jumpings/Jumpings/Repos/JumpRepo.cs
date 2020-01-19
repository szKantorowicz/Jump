using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jumpings.Repos
{
    public class InventoryRepo : BaseRepo<Jumper>, IRepo<Jumper>
    {
        public InventoryRepo()
        {
            Table = Context.Jumper;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jumper> ExcuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public List<Jumper> ExcuteQuery(string sql, object[] sqlParametrsObjects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jumper>> ExcuteQueryAsync(string sql)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jumper>> ExcuteQueryAsync(string sql, object[] sqlParametrsObjects)
        {
            throw new NotImplementedException();
        }

        public List<Jumper> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Jumper>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Jumper GetOne(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Jumper> GetOneAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
