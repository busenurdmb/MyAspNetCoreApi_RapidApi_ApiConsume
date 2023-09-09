using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.UnitOfWork
{
    public class Uow:IUow
    {

        private readonly Context _context;

        public Uow(Context context)
        {
            _context = context;
        }

     public   IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public IDontBaseEntityRepository<T> GetRepositoryDontBase<T>() where T : class
        {
            return new DontBaseEntityRepository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
