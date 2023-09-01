using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.ContactDtos
{
    public class ContactUpdateDto:IUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int MessageCategoryID { get; set; }
        public DateTime Date { get; set; }
    }
}
