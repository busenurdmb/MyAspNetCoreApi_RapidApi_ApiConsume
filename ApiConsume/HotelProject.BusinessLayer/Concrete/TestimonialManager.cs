using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class TestimonialManager : GenericManager<TestimonialCreateDto, TestimonialUpdateDto, TestimonialListDto, Testimonial>, ITestimonialService
    {
        public TestimonialManager(IUow uow, IMapper mapper, IValidator<TestimonialCreateDto> createdtovalidator, IValidator<TestimonialUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
