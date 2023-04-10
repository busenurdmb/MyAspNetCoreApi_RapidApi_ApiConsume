using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {


        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;
        public StaffController(IStaffService stafService, IMapper mapper)
        {
            _staffService = stafService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var list=await _staffService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffCreateDto createDto)
        {
            if(!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            var value=_mapper.Map<StaffCreateDto>(createDto);
         var cretead= await  _staffService.CreateAsync(createDto);
            return Created(string.Empty, cretead);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var deletid = await _staffService.GetByIdAsync(id);
            _staffService.RemoveAsync(deletid);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var value =await _staffService.GetByIdAsync(id);
            return Ok(value);
            
        }
    }
}
