using AutoMapper;
using HotelProject.DtoLayer.ServiceDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceListDto,Service>().ReverseMap();
            CreateMap<ServiceUpdateDto,Service>().ReverseMap();
            CreateMap<ServiceCreateDto,Service>().ReverseMap();
        }
    }
}
