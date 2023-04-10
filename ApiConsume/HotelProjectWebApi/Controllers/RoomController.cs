using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService Roomservice)
        {
            _RoomService = Roomservice;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var list = _RoomService.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddRoom(Room Room)
        {
            _RoomService.TInsert(Room);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var deletid = _RoomService.TGetById(id);
            _RoomService.TDelete(deletid);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateRoom(Room Room)
        {
            _RoomService.TUpdate(Room);

            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var value = _RoomService.TGetById(id);
            return Ok(value);

        }
    }
}
