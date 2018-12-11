using System;

namespace StayGreen.Models.Schema
{
    public class CoffeePreparationCoffee
    {
        public Guid CoffeePreparationId { get; set; }
        public Guid CoffeeId { get; set; }

        //Foreign keys
        public virtual CoffeePreparation CoffeePreparation { get; set; }
        public virtual Coffee Coffee { get; set; }

        public string Property { get; set; }
    }
}
