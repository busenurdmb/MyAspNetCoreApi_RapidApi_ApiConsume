using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.ServiceDtos;
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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService stafService)
        {
            _ServiceService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var list = await _ServiceService.GetAllAsync();
            return Ok(list);
            //var list = await _ServiceService.TGetList();
            //return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceCreateDto createDto)
        {
            var response = await _ServiceService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var data = await _ServiceService.GetByIdAsync<ServiceListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _ServiceService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(ServiceUpdateDto updateDto)
        {
            var checkstaf = await _ServiceService.GetByIdAsync<ServiceListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _ServiceService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var data = await _ServiceService.GetByIdAsync<ServiceListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
    }
}
