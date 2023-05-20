using HotelProject.WebUI.Dtos.Booking;
using HotelProject.WebUI.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
      
        public async  Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responmessage = await client.GetAsync("http://localhost:58806/api/Booking");
            if (responmessage.IsSuccessStatusCode)
            {
                var jsondata= await responmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ListBookingDto>>(jsondata);
                return View(value);
            }
            return View();
        }
      
        public async Task<IActionResult> ApprovedRezervation(UpdateRezervesionDto dto)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
          
            //dto.Status = "Onaylandı";
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:58806/api/Booking/ApprovedBookingupdate", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
