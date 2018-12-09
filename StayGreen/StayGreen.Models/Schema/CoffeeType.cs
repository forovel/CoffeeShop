using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class CoffeeType : NamedEntity<Guid>
    {
        //Reverse navigation
        public virtual ICollection<CoffeePriseCoffeeType> CoffeePrisesCoffeeTypes { get; set; }

        public CoffeeType()
        {
            CoffeePrisesCoffeeTypes = new List<CoffeePriseCoffeeType>();
        }
    }
}
