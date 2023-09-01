using AutoMapper;
using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class WorkLocationProfiles : Profile
    {
        public WorkLocationProfiles()
        {
            CreateMap<WorkLocation,WorkLocationCreateDto>().ReverseMap();
            CreateMap<WorkLocation, WorkLocationListDto>().ReverseMap();
            CreateMap<WorkLocation, WorkLocationUpdateDto>().ReverseMap();
        }
    }
}
