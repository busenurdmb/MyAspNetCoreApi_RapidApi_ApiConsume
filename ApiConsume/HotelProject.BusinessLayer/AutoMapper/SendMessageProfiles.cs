using AutoMapper;
using HotelProject.DtoLayer.SendMessageDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class SendMessageProfiles : Profile
    {
        public SendMessageProfiles()
        {
            CreateMap<SendMessage,SendMessageCreateDto>().ReverseMap();
            CreateMap<SendMessage, SendMessageUpdateDto>().ReverseMap();
            CreateMap<SendMessage, SendMessageListDto>().ReverseMap();
        }
    }
}
