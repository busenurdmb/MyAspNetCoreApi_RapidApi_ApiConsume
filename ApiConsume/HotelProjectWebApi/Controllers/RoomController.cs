using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.RoomDtos;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService stafService)
        {
            _RoomService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> RoomList()
        {
            var list = await _RoomService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomCreateDto createDto)
        {
            var response = await _RoomService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var data = await _RoomService.GetByIdAsync<RommListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _RoomService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(RoomUpdateDto updateDto)
        {
            var checkstaf = await _RoomService.GetByIdAsync<RommListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _RoomService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var data = await _RoomService.GetByIdAsync<RommListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }

    }
}
