using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : GenericManager<Service>, IServiceService
    {
        private readonly IUow _uow;

        public ServiceManager(IUow uow) : base(uow)
        {
            _uow = uow;
        }

        public void Delete(Service t)
        {
            _uow.GetRepository<Service>().Delete(t);
            _uow.SaveChanges();
        }

        public Service GetById(int id)
        {
            return _uow.GetRepository<Service>().GetById(id);
        }

        public List<Service> GetList()
        {
            return _uow.GetRepository<Service>().GetList();
        }

        public void Insert(Service t)
        {
            _uow.GetRepository<Service>().Insert(t);
            _uow.SaveChanges();
        }

        public void Update(Service t)
        {
            _uow.GetRepository<Service>().Update(t);
            _uow.SaveChanges();

        }
    }
}
