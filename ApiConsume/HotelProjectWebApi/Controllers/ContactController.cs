using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService stafService)
        {
            _ContactService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var list = await _ContactService.GetAllAsync();
            return Ok(list);
            //var list = await _ContactService.TGetList();
            //return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(ContactCreateDto createDto)
        {
            createDto.Date=Convert.ToDateTime(DateTime.Now);
            var response = await _ContactService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var data = await _ContactService.GetByIdAsync<ContactListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _ContactService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(ContactUpdateDto updateDto)
        {
            var checkstaf = await _ContactService.GetByIdAsync<ContactListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _ContactService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var data = await _ContactService.GetByIdAsync<ContactListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
        [HttpGet("GetContactCount")]
        public  IActionResult GetContactCount()
        {
            return Ok(_ContactService.coontactcount());
        }

    }
}
