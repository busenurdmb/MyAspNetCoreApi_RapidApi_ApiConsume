using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.DtoLayer.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService stafService)
        {
            _TestimonialService = stafService;

        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var list = await _TestimonialService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialCreateDto createDto)
        {
            var response = await _TestimonialService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var data = await _TestimonialService.GetByIdAsync<TestimonialListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _TestimonialService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateDto updateDto)
        {
            var checkstaf = await _TestimonialService.GetByIdAsync<TestimonialListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _TestimonialService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var data = await _TestimonialService.GetByIdAsync<TestimonialListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }

    }
}
