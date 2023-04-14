using HotelProject.DtoLayer.Interfaces;

namespace HotelProject.WebUI.Models.Staff
{
    public class StaffViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }
        //var result = JsonSerializer.Deserialize<List<StaffViewModel>>(jsondata, new JsonSerializerOptions
        //{
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //});
    }
}
