using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.WorkLocationDtos
{
    public class WorkLocationviewdto:IDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string WorklLocationName { get; set; }
        public int WorklLocationID { get; set; }
    }
}
