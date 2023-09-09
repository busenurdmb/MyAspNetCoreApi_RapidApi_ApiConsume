using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            return Ok(_staffService.Staffcount());
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            return Ok(_bookingService.Bookingcount());
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            return Ok(_appUserService.AppUsercount());
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            return Ok(_roomService.Roomcount());
        }
    }
}
