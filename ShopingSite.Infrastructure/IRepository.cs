using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopingSite.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteFilteredListAsync(Expression<Func<T, bool>> where);
        Task<T> GetById(Guid Id);
        T GetFirstItem(Expression<Func<T, bool>> where);
        Task<T> GetFirstItemAsync(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAllList();
        Task<List<T>> GetAllListAsync();
        IEnumerable<T> GetFilteredList(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetFilteredListAsync(Expression<Func<T, bool>> where);

    }
}
