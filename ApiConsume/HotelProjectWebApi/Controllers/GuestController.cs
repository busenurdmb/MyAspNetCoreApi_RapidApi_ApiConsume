using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.GuestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;

        public GuestController(IGuestService stafService)
        {
            _GuestService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> GuestList()
        {
            var list = await _GuestService.GetAllAsync();
            return Ok(list);
            //var list = await _GuestService.TGetList();
            //return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(GuestCreateDto createDto)
        {
            var response = await _GuestService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var data = await _GuestService.GetByIdAsync<GuestListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _GuestService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateGuest(GuestUpdateDto updateDto)
        {
            var checkstaf = await _GuestService.GetByIdAsync<GuestListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _GuestService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuest(int id)
        {
            var data = await _GuestService.GetByIdAsync<GuestListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
    }
}
