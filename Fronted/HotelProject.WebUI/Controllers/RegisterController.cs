using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        //private readonly Context _Context;
        //private readonly RoleManager<AppRole> _roleManager;

        //public RegisterController(UserManager<AppUser> userManager/*, Context context, RoleManager<AppRole> roleManager*/)
        //{
        //    _userManager = userManager;
        //    _Context = context;
        //    _roleManager = roleManager;
        //}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewUser p)
        {

            if (ModelState.IsValid)
            {
                var appuser = new AppUser()
                {
                    Name = p.Name,
                    SurName = p.SurName,
                    Email = p.Mail,
                    UserName = p.UserName

                };
                var result = await _userManager.CreateAsync(appuser, p.Password);
                if (result.Succeeded)
                 {
                //        var memberRole = await _roleManager.FindByNameAsync("Member");
                //        if (memberRole == null)
                //        {
                //            await _roleManager.CreateAsync(new()
                //            {
                //                Name = "Member",
                //                CreatTime = DateTime.Now,
                //            });
                //        }
                //        await _userManager.AddToRoleAsync(user, "Member");
                        return RedirectToAction("Index", "Login");
                    }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
            return View(p);

        }
        }
    }

