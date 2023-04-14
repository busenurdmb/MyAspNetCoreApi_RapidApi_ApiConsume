using AutoMapper;
using HotelProject.DtoLayer.SubscribeDto;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class SubscribeProfile : Profile
    {
        public SubscribeProfile()
        {
            CreateMap<SubscribeListDto, Subscribe>().ReverseMap();
            CreateMap<SubscribeUpdateDto, Subscribe>().ReverseMap();
            CreateMap<SubscribeCreateDto, Subscribe>().ReverseMap();
        }
    }
}
