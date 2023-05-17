

using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Service
{
    public class AddServiceViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Hizmet ikon linki giriniz")]

        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet title linki giriniz")]
      //  [StringLength(100,ErrorMessage ="100 harfi geçmiyor")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması  giriniz")]

        public string Description { get; set; }
    }
}
