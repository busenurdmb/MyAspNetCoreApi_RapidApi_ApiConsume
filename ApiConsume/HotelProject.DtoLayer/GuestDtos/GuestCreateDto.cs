﻿using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.GuestDtos
{
   public class GuestCreateDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string city { get; set; }
    }
}