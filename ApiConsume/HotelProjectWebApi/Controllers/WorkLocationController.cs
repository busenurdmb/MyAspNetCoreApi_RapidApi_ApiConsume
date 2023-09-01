using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.WorkLocationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _WorkLocationService;

        public WorkLocationController(IWorkLocationService WorkLocationService)
        {
            _WorkLocationService = WorkLocationService;

        }

        [HttpGet]
        public async Task<IActionResult> WorkLocationList()
        {
            var list = await _WorkLocationService.GetAllAsync();
            return Ok(list);
            //var list = await _WorkLocationService.TGetList();
            //return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(WorkLocationCreateDto createDto)
        {
            var response = await _WorkLocationService.CreateAsync(createDto);
            return Created(string.Empty, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var data = await _WorkLocationService.GetByIdAsync<WorkLocationListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            await _WorkLocationService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateWorkLocation(WorkLocationUpdateDto updateDto)
        {
            var checkstaf = await _WorkLocationService.GetByIdAsync<WorkLocationListDto>(updateDto.ID);
            if (checkstaf == null)
            {
                return NotFound(updateDto.ID);
            }
            var response = await _WorkLocationService.UpdateAsync(updateDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLocation(int id)
        {
            var data = await _WorkLocationService.GetByIdAsync<WorkLocationListDto>(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
    }
}
