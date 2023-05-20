using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Login
{
    public class LoginUserModel
    {
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifreyi Giriniz")]

        public string Password { get; set; }
    }
}
