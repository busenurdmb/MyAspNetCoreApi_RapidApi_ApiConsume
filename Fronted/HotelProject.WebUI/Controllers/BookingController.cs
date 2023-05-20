using HotelProject.DtoLayer.BookingDtos;
using HotelProject.WebUI.Dtos.Booking;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task< IActionResult> _AddBooking(BookingCreateDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            dto.Status = "Onay Bekliyor";
            dto.Description= string.Empty;
            var client =  _httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(dto);
            StringContent stringContent=new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responmessage = await client.PostAsync("http://localhost:58806/api/Booking", stringContent);
            if (responmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();

        }
    }
}
