﻿using AutoMapper;
using HotelProject.DtoLayer.AppUserDtos;
using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class AppUserProfiles : Profile
    {
        public AppUserProfiles()
        {
            CreateMap<AppUserCreateDto,AppUser>().ReverseMap();
            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUser,WorkLocationviewdto >().ForMember(x => x.WorklLocationName, dto => dto.MapFrom(x => x.WorkLocation.WorkLocationName)).ReverseMap();
        }
    }
}
