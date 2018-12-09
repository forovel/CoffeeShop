using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Product : Entity<Guid>
    {
        public Guid CategoryId { get; set; }
        public Guid RegionId { get; set; }

        //Foreign keys
        public virtual Category Category { get; set; }
        public virtual Region Region { get; set; }

        //Reverse navigation
        public virtual ICollection<ProductOrder> ProductsOrders { get; set; }
        public virtual ICollection<Coffee> Coffee { get; set; }

        public Product()
        {
            ProductsOrders = new List<ProductOrder>();
            Coffee = new List<Coffee>();
        }
    }
}
