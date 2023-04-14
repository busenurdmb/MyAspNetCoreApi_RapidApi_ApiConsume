using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Interfaces;
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
            //var list = await _staffService.TGetList();
            //return Ok(list);
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
            var data = await _staffService.GetByIdAsync<StaffListDto>(id);
            if(data == null)
            {
                return NotFound(id);
            }
            await _staffService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateStaff(StaffUpdateDto updateDto)
        {
            var checkstaf = await _staffService.GetByIdAsync<StaffListDto>(updateDto.ID);
            if(checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _staffService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var data = await _staffService.GetByIdAsync<StaffListDto>(id);
            if(data== null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }

    }
}
