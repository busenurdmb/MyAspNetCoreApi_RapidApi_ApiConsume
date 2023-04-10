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
    public class StaffManager : GenericManager<Staff>, IStaffService
    {
        private readonly IUow _uow;

        public StaffManager(IUow uow) : base(uow)
        {
            _uow = uow;
        }

        public void Delete(Staff t)
        {
            _uow.GetRepository<Staff>().Delete(t);
            _uow.SaveChanges();
        }

        public Staff GetById(int id)
        {
            return _uow.GetRepository<Staff>().GetById(id);
        }

        public List<Staff> GetList()
        {
            return _uow.GetRepository<Staff>().GetList();
        }

        public void Insert(Staff t)
        {
            _uow.GetRepository<Staff>().Insert(t);
            _uow.SaveChanges();
        }

        public void Update(Staff t)
        {
            _uow.GetRepository<Staff>().Update(t);
            _uow.SaveChanges();

        }
    }
}
