using HotelProject.WebUI.Dtos.Contact;
using HotelProject.WebUI.Dtos.SendMessage;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client=_httpClientFactory.CreateClient();
            var responmessage = await client.GetAsync("http://localhost:58806/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responmessage2 = await client.GetAsync("http://localhost:58806/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responmessage3 = await client.GetAsync("http://localhost:58806/api/SendMessage/GetSendMessageCount");


            if (responmessage.IsSuccessStatusCode)
            {
                var jsonData=await responmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ContactListDto>>(jsonData);
                var jsonData2 = await responmessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responmessage3.Content.ReadAsStringAsync();

                ViewBag.contactCount = jsonData2;
                ViewBag.SendMessageCount = jsonData3;
                return View(values);
            }
           
          
         
            return View();
           
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responmessage = await client.GetAsync("http://localhost:58806/api/SendMessage");

            var client2 = _httpClientFactory.CreateClient();
            var responmessage2 = await client.GetAsync("http://localhost:58806/api/SendMessage/GetSendMessageCount");

            if (responmessage.IsSuccessStatusCode)
            {
                var jsonData = await responmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SendMessageListDto>>(jsonData);
                var jsonData2 = await responmessage2.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsonData2;
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto
            createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "admin";
            createSendMessage.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:58806/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        public PartialViewResult SidebarAdminContactPartial()
        {
           return PartialView();
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            
            return PartialView();
        }
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:58806/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SendMessageListDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:58806/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ContactListDto>(jsonData);
                return View(values);
            }
            return View();
        }
        //public async Task<IActionResult> GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responmessage = await client.GetAsync("http://localhost:58806/api/Contact/GetContactCount");
        //    if (responmessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responmessage.Content.ReadAsStringAsync();
        //        //  var values = JsonConvert.DeserializeObject<List<ContactListDto>>(jsonData);
        //        ViewBag.data = jsonData;
        //        return View();
        //    }
        //    return View();
        //}
    }
}
