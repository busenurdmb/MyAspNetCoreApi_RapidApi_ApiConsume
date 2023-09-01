using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.SendMessageDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _SendMessageService;

        public SendMessageController(ISendMessageService SendMessageService)
        {
            _SendMessageService = SendMessageService;

        }

        [HttpGet]
        public async Task<IActionResult> SendMessageList()
        {
            var list = await _SendMessageService.GetAllAsync();
            return Ok(list);
            //var list = await _SendMessageService.TGetList();
            //return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(SendMessageCreateDto createDto)
        {
            var response = await _SendMessageService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSendMessage(int id)
        {
            var data = await _SendMessageService.GetByIdAsync<SendMessageListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _SendMessageService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateSendMessage(SendMessageUpdateDto updateDto)
        {
            var checkstaf = await _SendMessageService.GetByIdAsync<SendMessageListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _SendMessageService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendMessage(int id)
        {
            var data = await _SendMessageService.GetByIdAsync<SendMessageListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendCount()
        {
            return Ok(_SendMessageService.SendMessagecount());
        }
    }
}
