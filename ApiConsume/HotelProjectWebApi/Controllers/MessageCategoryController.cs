using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.MessageCategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _MessageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageService)
        {
            _MessageCategoryService = messageService;

        }

        [HttpGet]
        public async Task<IActionResult> MessageCategoryList()
        {
            var list = await _MessageCategoryService.GetAllAsync();
            return Ok(list);
            //var list = await _MessageCategoryService.TGetList();
            //return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddMessageCategory(MessageCategoryCreateDto createDto)
        {
            var response = await _MessageCategoryService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageCategory(int id)
        {
            var data = await _MessageCategoryService.GetByIdAsync<MessageCategoryListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _MessageCategoryService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessageCategory(MessageCategoryUpdateDto updateDto)
        {
            var checkstaf = await _MessageCategoryService.GetByIdAsync<MessageCategoryListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _MessageCategoryService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageCategory(int id)
        {
            var data = await _MessageCategoryService.GetByIdAsync<MessageCategoryListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }

    }
}
