using StayGreen.Models.Enums;
using StayGreen.Models.Schema.Common;
using System;

namespace StayGreen.Models.Schema
{
    public class CoffeePrise : Entity<Guid>
    {
        public Guid CoffeeId { get; set; }
        public CoffeeWeightType CoffeeWeight { get; set; }
        public double Prise { get; set; }

        //Foreign keys
        public virtual Coffee Coffee { get; set; }
    }
}
