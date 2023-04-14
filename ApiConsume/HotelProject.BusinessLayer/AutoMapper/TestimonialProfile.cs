using AutoMapper;
using HotelProject.DtoLayer.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<TestimonialListDto,Testimonial>().ReverseMap();
            CreateMap<TestimonialUpdateDto,Testimonial>().ReverseMap();
            CreateMap<TestimonialCreateDto,Testimonial>().ReverseMap();
        }
    }
}
