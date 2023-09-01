using AutoMapper;
using HotelProject.DtoLayer.MessageCategoryDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class MessageCategoryProfiles : Profile
    {
        public MessageCategoryProfiles()
        {
            CreateMap<MessageCategory,MessageCategoryListDto>();
            CreateMap<MessageCategory,MessageCategoryUpdateDto>();
            CreateMap<MessageCategory,MessageCategoryCreateDto>();

        }
    }
}
