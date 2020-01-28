using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Jumpings.Repos
{
    public abstract class BaseRepo<T> : IRepo<T>, IDisposable where T : class, new()
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); // moze byc private readonly
        protected JumpingsContext Context;
        protected DbSet<T> Table;
        bool disposed = false; // może być prvate i nie mus byc inicjalizowane

        public T GetOne(int id) => Table.Find(id);

        public Task<T> GetOneAsync(int id) => Table.FindAsync(id); // async await

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return await SaveChangesAsync();
        }

        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }
        public Task<int> AddRangeAsync(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public async Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            // todo async/await
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }

        public int Delete(int id)
        {
            var entity = GetOne(id);
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        // W blockach catch zamiast rzucania wyjątku dodać logowanie błędów
        private int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                logger.Error("DbUpdateConcurrencyException", ex);// zamień kolejność parametrów i lepszy message
                throw; // usuń

            }
            catch (DbUpdateException ex)
            {
                logger.Error("DbUpdateException", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }
            catch (CommitFailedException ex)
            {
                logger.Error("CommitFailedException", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }
            catch (Exception ex)
            {
                logger.Error("Exception", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }

            //return
        }

        // W blockach catch zamiast rzucania wyjątku dodać logowanie błędów
        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                logger.Error("DbUpdateConcurrencyException", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }
            catch (DbUpdateException ex)
            {
                logger.Error("DbUpdateException", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }
            catch (CommitFailedException ex)
            {
                logger.Error($"Został zgłoszony wyjątek {ex.GetType().Name}.", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }
            catch (Exception ex)
            {
                logger.Error("Exception", ex);// zamień kolejność parametrów i lepszy message
                throw;// usuń
            }

            //return
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // moze byc protected
        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Context.Dispose();
            }

            disposed = true;
        }
    }

}
