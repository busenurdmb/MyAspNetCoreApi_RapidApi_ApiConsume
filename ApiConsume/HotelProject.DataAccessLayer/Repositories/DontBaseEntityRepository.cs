using HotelProject.CommonLayer.Enums;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class DontBaseEntityRepository<T>: IDontBaseEntityRepository<T> where T : class
    {
        private readonly Context _context;

        public DontBaseEntityRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selecter, OrderByType orderByType = OrderByType.DESC)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selecter, OrderByType orderByType = OrderByType.DESC)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ?
                 await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                 await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }

        //public void Delete(T t)
        //{
        //    _context.Set<T>().Remove(t);

        //}

        //public  T GetById(int id)
        //{
        //    return  _context.Set<T>().Find(id);
        //}

        public async Task<List<T>> GetList()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

     

        public int GetCount()
        {
            return _context.Set<T>().Count();

        }

        public  List<AppUser> UserListWithWorkLocation()
        {
            return  _context.Users.Include(x => x.WorkLocation).ToList();
        }

        
    }
}
