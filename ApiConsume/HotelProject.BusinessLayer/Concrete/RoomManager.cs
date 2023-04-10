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
    public class RoomManager : GenericManager<Room>,IRoomService
    {
        private readonly IUow _uow;

        public RoomManager(IUow uow) : base(uow)
        {
            _uow = uow;
        }

        public void Delete(Room t)
        {
            _uow.GetRepository<Room>().Delete(t);
            _uow.SaveChanges();
        }

        public Room GetById(int id)
        {
            return _uow.GetRepository<Room>().GetById(id);
        }

        public List<Room> GetList()
        {
            return _uow.GetRepository<Room>().GetList();
        }

        public void Insert(Room t)
        {
            _uow.GetRepository<Room>().Insert(t);
            _uow.SaveChanges();
        }

        public void Update(Room t)
        {
           _uow.GetRepository<Room>().Update(t);
            _uow.SaveChanges();

        }
    }
}
