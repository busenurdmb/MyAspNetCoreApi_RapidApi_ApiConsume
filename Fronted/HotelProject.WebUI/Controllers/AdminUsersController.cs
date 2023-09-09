using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.Room;
using HotelProject.WebUI.Models.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
        //private readonly UserManager<AppUser> _userManager;

        //public AdminUsersController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //    var values = _userManager.Users.ToList();

        //    return View(values);
        //}
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responmmessage = await client.GetAsync("http://localhost:58806/api/AppUser/AppUserList");
            if (responmmessage.IsSuccessStatusCode)
            {
                var jsondata = await responmmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAppUserList>>(jsondata);
                return View(value);
            }

            return View();
        }
        //tablo normal hali
        public async Task<IActionResult> userlist()
        {
            var client = _httpClientFactory.CreateClient();
            var responmmessage = await client.GetAsync("http://localhost:58806/api/AppUser/AppUserList");
            if (responmmessage.IsSuccessStatusCode)
            {
                var jsondata = await responmmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAppUserList>>(jsondata);
                return View(value);
            }

            return View();
        }
        public async Task<IActionResult> UserListWorkLocation()
        {
            var client = _httpClientFactory.CreateClient();
            var responmmessage = await client.GetAsync("http://localhost:58806/api/AppUser/AppUserWorkLocationList");
            if (responmmessage.IsSuccessStatusCode)
            {
                var jsondata = await responmmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAppUserWorkLocation>>(jsondata);
                return View(value);
            }

            return View();
        }
    }
}
