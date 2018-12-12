﻿using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class CoffeePrise : Entity<Guid>
    {
        public string FullWeigth { get; set; }
        public string HalfWeight { get; set; }
        public string QuarterWeigth { get; set; }

        //Reverse navigation
        public virtual ICollection<Coffee> Coffee { get; set; }

        public CoffeePrise()
        {
            Coffee = new List<Coffee>();
        }
    }
}