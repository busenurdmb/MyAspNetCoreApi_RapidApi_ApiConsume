using HotelProject.DtoLayer.BookingDtos;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<BookingCreateDto,BookingUpdateDto,BookingListDto,Booking>
    {
        Task<BookingUpdateDto> BoookingStatusChangedApproved(BookingUpdateDto Dto);
        Task<BookingUpdateDto> BookingStatusChangedCancel(BookingUpdateDto Dto);
        Task<BookingUpdateDto> BookingStatusChangedWait(BookingUpdateDto Dto);
        int Bookingcount();
        Task<IList<BookingListDto>> Last6T();
    }
}
