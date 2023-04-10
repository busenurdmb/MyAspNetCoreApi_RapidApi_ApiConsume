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
    public class SubscribeManager : GenericManager<Subscribe>, ISubscribeService
    {
        private readonly IUow _uow;

        public SubscribeManager(IUow uow) : base(uow)
        {
            _uow = uow;
        }

        public void Delete(Subscribe t)
        {
            _uow.GetRepository<Subscribe>().Delete(t);
            _uow.SaveChanges();
        }

        public Subscribe GetById(int id)
        {
            return _uow.GetRepository<Subscribe>().GetById(id);
        }

        public List<Subscribe> GetList()
        {
            return _uow.GetRepository<Subscribe>().GetList();
        }

        public void Insert(Subscribe t)
        {
            _uow.GetRepository<Subscribe>().Insert(t);
            _uow.SaveChanges();
        }

        public void Update(Subscribe t)
        {
            _uow.GetRepository<Subscribe>().Update(t);
            _uow.SaveChanges();

        }
    }
}
