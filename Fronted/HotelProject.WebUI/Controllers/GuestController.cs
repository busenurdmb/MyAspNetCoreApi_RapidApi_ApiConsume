using FluentValidation;
using HotelProject.WebUI.Dtos.Guest;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IValidator<GuestCreateDtoo> _createvalidator;
        private readonly IValidator<GuestUpdateDto> _updatevalidator;
        public GuestController(IHttpClientFactory httpClientFactory/*, IValidator<GuestCreateDtoo> validator*/, IValidator<GuestUpdateDto> updatevalidator)
        {
            _httpClientFactory = httpClientFactory;
            //_createvalidator = validator;
            _updatevalidator = updatevalidator;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responmmessage = await client.GetAsync("http://localhost:58806/api/Guest");
            if (responmmessage.IsSuccessStatusCode)
            {
                var jsondata = await responmmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<GuestListDto>>(jsondata);
                return View(value);
            }

            return View();
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(GuestCreateDtoo model)
        {
            //var result = _createvalidator.Validate(model);
            //if (result.IsValid)
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:58806/api/Guest", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();

            }
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //}
            else
            {
                return View();
            }
            




        }
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:58806/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:58806/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GuestUpdateDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuest(GuestUpdateDto model)
        {
            //var result = _updatevalidator.Validate(model);
            //if (result.IsValid)
            if(ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:58806/api/Guest/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();

            }
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //}
            else
            {
               return View();
            }
            

        }

    }
}
