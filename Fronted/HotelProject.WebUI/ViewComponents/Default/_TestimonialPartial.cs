using HotelProject.WebUI.Dtos.Service;
using HotelProject.WebUI.Dtos.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _TestimonialPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responmmessage = await client.GetAsync("http://localhost:58806/api/Testimonial");
            if (responmmessage.IsSuccessStatusCode)
            {
                var jsondata = await responmmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);
                return View(value);
            }
            return View();
        }
    }
}
