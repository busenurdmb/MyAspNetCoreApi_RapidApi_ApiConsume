using AutoMapper;
using HotelProject.DtoLayer.GuestDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class GuestProfiles : Profile
    {
        public GuestProfiles()
        {
            CreateMap<Guest, GuestCreateDto>().ReverseMap();
            CreateMap<Guest, GuestUpdateDto>().ReverseMap();
            CreateMap<Guest, GuestListDto>().ReverseMap();
        }
    }
}
