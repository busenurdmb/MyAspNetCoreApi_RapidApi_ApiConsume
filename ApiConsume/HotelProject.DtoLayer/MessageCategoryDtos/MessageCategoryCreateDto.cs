using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.MessageCategoryDtos
{
   public class MessageCategoryCreateDto:IDto
    {
        public string MessageCategoryName { get; set; }
    }
}
