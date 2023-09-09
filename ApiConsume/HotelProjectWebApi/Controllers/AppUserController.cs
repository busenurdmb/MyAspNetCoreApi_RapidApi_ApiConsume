using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly Context _context;

        public AppUserController(IAppUserService appUserService, Context context)
        {
            _appUserService = appUserService;
            _context = context;
        }



        [HttpGet("AppUserList")]
        public async Task<IActionResult> AppUserList()
        {
            var list = await _appUserService.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("AppUserWorkLocationList")]
        public IActionResult UserListworklocationt()
        {
            // var list = await _appUserService.UserListWithWorkLocation();
            
            var values =  _context.Users.Include(x => x.WorkLocation).Select(y => new WorkLocation
            {
                Name = y.Name,
                SurName = y.SurName,
                WorklLocationID = y.WorkLocationId,
                WorklLocationName = y.WorkLocation.WorkLocationName,
                Gender=y.Gender,
                City=y.City,
                Country=y.Country,
                ImageUrl=y.ImageUrl

                
            }).ToList();
            return Ok( values);
        }
    }
}
