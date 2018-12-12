using StayGreen.Models.Schema.Common;
using System;

namespace StayGreen.Models.Schema
{
    public class OrderedCoffee : Entity<Guid>
    {
        public string CoffeeName { get; set; }
        public string CoffeeCategory { get; set; }
        public string CoffeeWeight { get; set; }
        public string CoffeePrise { get; set; }
        public string CoffeeType { get; set; }

        public Guid OrderId { get; set; }
        public Guid AttachmentId { get; set; }

        //Foreign keys
        public Order Order { get; set; }
        public Attachment Attachment { get; set; }
    }
}
