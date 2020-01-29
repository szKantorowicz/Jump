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
        private readonly static Logger logger = LogManager.GetCurrentClassLogger(); 
        protected JumpingsContext Context;
        protected DbSet<T> Table;
        private bool disposed = false; 

        public T GetOne(int id) => Table.Find(id);

        public async Task<T> GetOneAsync(int id) => await Table.FindAsync(id);

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

        public async Task<int> DeleteAsync(int id)
        {
            var entity = GetOne(id);
            Context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
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

        private int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }
            catch (DbUpdateException ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }
            catch (CommitFailedException ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }

            return 0;
        }

        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }
            catch (DbUpdateException ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }
            catch (CommitFailedException ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Został zgłoszony wyjątek {ex.GetType().Name}.");
            }

            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
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
