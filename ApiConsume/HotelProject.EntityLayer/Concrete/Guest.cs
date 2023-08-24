using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
   public class Guest:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string city { get; set; }
    }
}
