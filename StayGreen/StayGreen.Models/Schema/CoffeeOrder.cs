using System;

namespace StayGreen.Models.Schema
{
    public class CoffeeOrder
    {
        public Guid CoffeeId { get; set; }
        public Guid OrderId { get; set; }

        //Foreign keys
        public virtual Coffee Coffee { get; set; }
        public virtual Order Order { get; set; }
    }
}
