using MD.AdvertisementApp.Common.Enums;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.DataAccess.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<T> Find(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracikng = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);
        Task Create(T entity);
        void Update(T entity, T unchanged);
    }
}
