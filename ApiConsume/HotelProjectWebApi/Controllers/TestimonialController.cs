using HotelProject.BusinessLayer.Abstract;
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
            var response = await _TestimonialService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateDto updateDto)
        {
            var response = await _TestimonialService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _TestimonialService.GetByIdAsync<TestimonialListDto>(id);
            return Ok(value);

        }

    }
}
