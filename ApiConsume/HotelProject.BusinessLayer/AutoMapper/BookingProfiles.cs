using AutoMapper;
using HotelProject.DtoLayer.BookingDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.AutoMapper
{
    public class BookingProfiles : Profile
    {
        public BookingProfiles()
        {
            CreateMap<BookingListDto, Booking>().ReverseMap();
            CreateMap<BookingUpdateDto, Booking>().ReverseMap();
            CreateMap<BookingCreateDto, Booking>().ReverseMap();
        }
    }
}
