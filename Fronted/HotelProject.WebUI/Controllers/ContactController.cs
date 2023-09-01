using HotelProject.DtoLayer.BookingDtos;
using HotelProject.WebUI.Dtos.Contact;
using HotelProject.WebUI.Dtos.MessageCategory;
using HotelProject.WebUI.Dtos.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responmmessage = await client.GetAsync("http://localhost:58806/api/MessageCategory");
          
                var jsondata = await responmmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MessageCategoryListDto>>(jsondata);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.MessageCategoryName,
                                                Value
                                                = x.ID.ToString()
                                            }).ToList();
            ViewBag.v = values2;
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
