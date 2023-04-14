﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.SubscribeDto;

using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;

        public SubscribeController(ISubscribeService stafService)
        {
            _SubscribeService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> SubscribeList()
        {
            var list = await _SubscribeService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddSubscribe(SubscribeCreateDto createDto)
        {
            var response = await _SubscribeService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var response = await _SubscribeService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(SubscribeUpdateDto updateDto)
        {
            var response = await _SubscribeService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribe(int id)
        {
            var value = await _SubscribeService.GetByIdAsync<SubscribeListDto>(id);
            return Ok(value);

        }

    }
}
