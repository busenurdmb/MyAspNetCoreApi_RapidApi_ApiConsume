using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responmessage = await client.GetAsync("http://localhost:58806/api/DashboardWidgets/StaffCount");
            
            var client2 = _httpClientFactory.CreateClient();
            var responmessage2 = await client.GetAsync("http://localhost:58806/api/DashboardWidgets/BookingCount");

            var client3 = _httpClientFactory.CreateClient();
            var responmessage3 = await client.GetAsync("http://localhost:58806/api/DashboardWidgets/AppUserCount");

            var client4 = _httpClientFactory.CreateClient();
            var responmessage4 = await client.GetAsync("http://localhost:58806/api/DashboardWidgets/RoomCount");
            if (responmessage.IsSuccessStatusCode)
            {
                var jsonData = await responmessage.Content.ReadAsStringAsync();
                var jsonData2 = await responmessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responmessage3.Content.ReadAsStringAsync();
                var jsonData4 = await responmessage4.Content.ReadAsStringAsync();
                ViewBag.staffCount = jsonData;
                ViewBag.BookingCount = jsonData2;
                ViewBag.AppUserCount = jsonData3;
                ViewBag.RoomCount = jsonData4;

            }
            return View();
        }
    }
}
