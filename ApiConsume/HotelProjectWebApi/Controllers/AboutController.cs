using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService stafService)
        {
            _AboutService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var list = await _AboutService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(AboutCreateDto createDto)
        {
            var response = await _AboutService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var data = await _AboutService.GetByIdAsync<AboutListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _AboutService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(AboutUpdateDto updateDto)
        {
            var checkstaf = await _AboutService.GetByIdAsync<AboutListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _AboutService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var data = await _AboutService.GetByIdAsync<AboutListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
    }
}
