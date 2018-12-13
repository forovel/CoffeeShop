using StayGreen.Models.Enums;
using StayGreen.Models.Schema.Common;
using System;

namespace StayGreen.Models.Schema
{
    public class OrderedCoffee : Entity<Guid>
    {
        public int Amount { get; set; }
        public double CoffeePrise { get; set; }
        public CoffeeWeightType CoffeeWeight { get; set; }
        public CoffeeRoastingType CoffeeRoasting { get; set; }

        public Guid? CoffeeId { get; set; }
        public Guid OrderId { get; set; }
        public Guid? AttachmentId { get; set; }

        //Foreign keys
        public virtual Coffee Coffee { get; set; }
        public virtual Order Order { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
