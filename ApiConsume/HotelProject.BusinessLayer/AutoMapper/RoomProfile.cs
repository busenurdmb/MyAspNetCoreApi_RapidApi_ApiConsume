using AutoMapper;
using HotelProject.DtoLayer.RoomDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class RoomProfile : Profile
    {
       public RoomProfile()
        {
            CreateMap<RommListDto,Room>().ReverseMap();
            CreateMap<RoomCreateDto,Room>().ReverseMap();
            CreateMap<RoomUpdateDto,Room>().ReverseMap();
        }
    }
}
