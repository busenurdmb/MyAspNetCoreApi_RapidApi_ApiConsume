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
    public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
    {
        private readonly IUow _uow;

        public TestimonialManager(IUow uow) : base(uow)
        {
            _uow = uow;
        }

        public void Delete(Testimonial t)
        {
            _uow.GetRepository<Testimonial>().Delete(t);
            _uow.SaveChanges();
        }

        public Testimonial GetById(int id)
        {
            return _uow.GetRepository<Testimonial>().GetById(id);
        }

        public List<Testimonial> GetList()
        {
            return _uow.GetRepository<Testimonial>().GetList();
        }

        public void Insert(Testimonial t)
        {
            _uow.GetRepository<Testimonial>().Insert(t);
            _uow.SaveChanges();
        }

        public void Update(Testimonial t)
        {
            _uow.GetRepository<Testimonial>().Update(t);
            _uow.SaveChanges();

        }
    }
}
