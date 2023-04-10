using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IUow _uow;

        public GenericManager(IUow uow)
        {
            _uow = uow;
        }

        public void TDelete(T t)
        {
            _uow.GetRepository<T>().Delete(t);
            _uow.SaveChanges();
           
        }

        public T TGetById(int id)
        {
         return   _uow.GetRepository<T>().GetById(id);
            
        }

        public List<T> TGetList()
        {
            return _uow.GetRepository<T>().GetList();    
        }
        public void TInsert(T t)
        {
           _uow.GetRepository<T>().Insert(t);
            _uow.SaveChanges();
        }

        public void TUpdate(T t)
        {
            
            _uow.GetRepository<T>().Update(t);
            _uow.SaveChanges();
        }
    }
}
