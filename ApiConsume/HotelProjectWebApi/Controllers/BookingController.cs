using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService stafService)
        {
            _BookingService = stafService;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var list = await _BookingService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingCreateDto createDto)
        {
            var response = await _BookingService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var data = await _BookingService.GetByIdAsync<BookingListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _BookingService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(BookingUpdateDto updateDto)
        {
            var checkstaf = await _BookingService.GetByIdAsync<BookingListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _BookingService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var data = await _BookingService.GetByIdAsync<BookingListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
        [HttpPut("ApprovedBookingupdate")]
        public async Task<IActionResult> ApprovedBookingupdate(BookingUpdateDto updateDto)
        {
            var checkstaf = await _BookingService.GetByIdAsync<BookingListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _BookingService.BoookingStatusChangedApproved(updateDto);
            return NoContent();
        }
        [HttpPut("CancelBookingupdate")]
        public async Task<IActionResult> CancelBookingupdate(BookingUpdateDto updateDto)
        {
            var checkstaf = await _BookingService.GetByIdAsync<BookingListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _BookingService.BookingStatusChangedCancel(updateDto);
            return NoContent();
        }
        [HttpPut("WaitBookingupdate")]
        public async Task<IActionResult> WaitBookingupdate(BookingUpdateDto updateDto)
        {
            var checkstaf = await _BookingService.GetByIdAsync<BookingListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _BookingService.BookingStatusChangedWait(updateDto);
            return NoContent();
        }
        [HttpGet("Booking6LastList")]
        public async Task<IActionResult> Booking6LastList()
        {
            return Ok(await _BookingService.Last6T());
        }
    }
}
