using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            
        }

        public  T GetById(int id)
        {
            return  _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
           _context.Set<T>().Add(t);
            
        }

        public void Update(T entity)
        {

           var updateEntity=_context.Set<T>().Find(entity.ID);
            _context.Entry(updateEntity).CurrentValues.SetValues(entity);
        }
    }
}
