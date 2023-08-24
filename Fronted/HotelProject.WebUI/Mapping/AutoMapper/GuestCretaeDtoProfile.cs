using AutoMapper;
using HotelProject.DtoLayer.GuestDtos;
using HotelProject.WebUI.Dtos.Guest;

namespace HotelProject.WebUI.Mapping.AutoMapper
{
    public class GuestCretaeDtoProfile:Profile
    {
        public GuestCretaeDtoProfile()
        {
            CreateMap<GuestCreateDtoo,GuestCreateDto>();
        }
    }
}
