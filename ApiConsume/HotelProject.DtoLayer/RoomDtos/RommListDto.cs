﻿using HotelProject.DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.RoomDtos
{
    public class RommListDto:IDto
    {
        public int ID { get; set; }
        public string RommNumber { get; set; }
        public string RommCoverImage { get; set; }
        public int Price { get; set; }
        public int Title { get; set; }
        public int BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}