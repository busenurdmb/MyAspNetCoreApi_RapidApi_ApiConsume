using HotelProject.DtoLayer.Interfaces;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.AppUserDtos
{
   public class AppUserListDto:IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public int WorkLocationId { get; set; }
        public WorkLocation WorkLocation { get; set; }
    }
}
