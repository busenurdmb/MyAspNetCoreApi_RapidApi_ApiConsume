using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {


        private readonly IStaffService _staffService;

        public StaffController(IStaffService stafService)
        {
            _staffService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var list = await _staffService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffCreateDto createDto)
        {
            var response = await _staffService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
          var response=await _staffService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateStaff(StaffUpdateDto updateDto)
        {
            var response = await _staffService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var value = await _staffService.GetByIdAsync<StaffListDto>(id);
            return Ok(value);

        }

    }
}
