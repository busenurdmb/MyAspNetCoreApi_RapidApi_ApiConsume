using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.WorkLocationDtos
{
    public class WorkLocationCreateDto:IDto
    {
        
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }
    }
}
