﻿using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto :IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public bool RentStatus { get; set; }
        public int FindeksScore { get; set; }

    }
}
