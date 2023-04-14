using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
    public class DENEMEController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public DENEMEController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        //private readonly IStaffService _staffService;
        //private readonly IValidator<StaffCreateDto> _validator;
        //private readonly IMapper _mapper;

        //public DENEMEController(IStaffService stafService, IMapper mapper, IValidator<StaffCreateDto> validator)
        //{
        //    _staffService = stafService;
        //    _mapper = mapper;
        //    _validator = validator;
        //}

        [HttpGet]
        public IActionResult StaffList()
        {
            var list = _staffService.GetAllAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffCreateDto dto)
        {
            var response=await _staffService.CreateAsync(dto);
            return Ok(response);
        }
    }
}
