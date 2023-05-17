using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
   public class AppUser:IdentityUser<int>
    {
        public int Name { get; set; }
        public int SurName { get; set; }
        public int City { get; set; }
    }
}
