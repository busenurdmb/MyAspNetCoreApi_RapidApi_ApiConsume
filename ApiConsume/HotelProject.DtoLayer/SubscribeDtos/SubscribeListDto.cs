﻿using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.SubscribeDto
{
   public class SubscribeListDto:IDto
    {
        public int ID { get; set; }
        public string Mail { get; set; }
    }
}
