using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.MessageCategoryDtos
{
    public class MessageCategoryUpdateDto:IUpdateDto
    {
        public int ID { get; set; }
        public string MessageCategoryName { get; set; }
    }
}
