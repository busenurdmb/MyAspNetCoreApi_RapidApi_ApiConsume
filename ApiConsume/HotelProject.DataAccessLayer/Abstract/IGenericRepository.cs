using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T entity);
        List<T> GetList();
        T GetById(int id);
    }
}
