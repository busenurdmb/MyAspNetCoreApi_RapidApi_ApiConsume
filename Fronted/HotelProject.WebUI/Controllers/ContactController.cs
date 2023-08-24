using HotelProject.DtoLayer.BookingDtos;
using HotelProject.WebUI.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SendMessage(ContactCreateDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            dto.Date = DateTime.Parse(DateTime.Now.ToString());
            
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responmessage = await client.PostAsync("http://localhost:58806/api/Contact", stringContent);
            if (responmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();

        }
    }
}
