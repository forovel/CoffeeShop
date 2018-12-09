using System;

namespace StayGreen.Models.Schema
{
    public class CoffeePriseCoffeeType
    {
        public Guid PriseId { get; set; }
        public Guid TypeId { get; set; }

        //Foreign keys
        public virtual CoffeePrise Prise { get; set; }
        public virtual CoffeeType Type { get; set; }
    }
}
