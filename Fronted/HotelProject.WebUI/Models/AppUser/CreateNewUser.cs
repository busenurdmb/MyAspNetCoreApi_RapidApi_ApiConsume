using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Models.AppUser
{
    public class CreateNewUser
    {
        [Required(ErrorMessage ="Ad ALANI GEREKLİDİR")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyadı ALANI GEREKLİDİR")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Kullanıcnı adı ALANI GEREKLİDİR")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mail ALANI GEREKLİDİR")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre ALANI GEREKLİDİR")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar ALANI GEREKLİDİR")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
        //public int WorkLocationId { get; set; }
    }
}
