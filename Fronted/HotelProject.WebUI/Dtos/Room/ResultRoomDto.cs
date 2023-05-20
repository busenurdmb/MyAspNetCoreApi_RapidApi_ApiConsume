namespace HotelProject.WebUI.Dtos.Room
{
    public class ResultRoomDto
    {
        public int ID { get; set; }
        public string RommNumber { get; set; }
        public string RommCoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public int BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
