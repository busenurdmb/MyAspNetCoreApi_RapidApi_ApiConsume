using AutoMapper;
using HotelProject.DtoLayer.AboutDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About,AboutListDto>().ReverseMap();
            CreateMap<About, AboutUpdateDto>().ReverseMap();
            CreateMap<About, AboutCreateDto>().ReverseMap();
        }
    }
}
