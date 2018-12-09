using System;

namespace StayGreen.Models.Schema
{
    public class ProductOrder
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        //Foreign keys
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
