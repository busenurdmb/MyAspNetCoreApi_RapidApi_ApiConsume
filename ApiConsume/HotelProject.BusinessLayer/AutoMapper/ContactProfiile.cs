using AutoMapper;
using HotelProject.DtoLayer.ContactDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class ContactProfiile : Profile
    {
        public ContactProfiile()
        {
            CreateMap<ContactCreateDto, Contact>().ReverseMap();
            CreateMap<ContactListDto, Contact>().ReverseMap();
            CreateMap<ContactUpdateDto, Contact>().ReverseMap();
        }
    }
}
