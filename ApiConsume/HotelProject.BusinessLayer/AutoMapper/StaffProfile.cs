using AutoMapper;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffCreateDto,Staff>().ReverseMap();
            CreateMap<StaffListDto, Staff>().ReverseMap();
            CreateMap<StaffUpdateDto, Staff>().ReverseMap();
        }
    }
}
