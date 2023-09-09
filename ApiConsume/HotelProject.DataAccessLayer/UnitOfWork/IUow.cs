using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.UnitOfWork
{
    public interface IUow
    {
        IGenericRepository<T> GetRepository<T>() where T :BaseEntity;
        IDontBaseEntityRepository<T> GetRepositoryDontBase<T>() where T :class;
        Task SaveChangesAsync();
    }
}
