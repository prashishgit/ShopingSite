using ShoppinSite.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopingSite.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private ShoppinSite.Database.ApplicationDbContext dataContext;
        private readonly DbSet<T> dbset;
        protected AuthenticationRepository authenticationRepository;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
            authenticationRepository = new AuthenticationRepository();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected ApplicationDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual async Task DeleteFilteredListAsync(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = await dbset.Where<T>(where).ToListAsync();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbset.FindAsync(id);
        }

        public T GetFirstItem(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        public async Task<T> GetFirstItemAsync(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).FirstOrDefaultAsync<T>();
        }

        public virtual IEnumerable<T> GetAllList()
        {
            return dbset.ToList();
        }

        public virtual async Task<List<T>> GetAllListAsync()
        {
            return await dbset.ToListAsync();
        }

        public virtual IEnumerable<T> GetFilteredList(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetFilteredListAsync(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).ToListAsync();
        }

        protected Guid CurrentUserId()
        {
            return authenticationRepository.GetUserId();
        }
    }
}
