using HotelProject.WebUI.Dtos.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4StaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responmessage = await client.GetAsync("http://localhost:58806/api/Staff/Staff4LastList");
            if (responmessage.IsSuccessStatusCode)
            {
                var jsonData = await responmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Result4StafflistDto>>(jsonData);


                return View(values);
            }
            return View();
        }
    }
}
