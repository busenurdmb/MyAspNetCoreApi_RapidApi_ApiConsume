using HotelProject.CommonLayer.Enums;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IDontBaseEntityRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        List<AppUser> UserListWithWorkLocation();
      
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selecter, OrderByType orderByType = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selecter, OrderByType orderByType = OrderByType.DESC);
        Task<T> FindAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
       
        int GetCount();

        //void Insert(T t);
        //void Delete(T t);
        //void Update(T entity);
        Task<List<T>> GetList();

        //T GetById(int id);
    }
}
