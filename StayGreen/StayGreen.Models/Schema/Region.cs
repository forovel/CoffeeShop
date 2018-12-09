using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Region : NamedEntity<Guid>
    {
        public virtual ICollection<Product> Products { get; set; }

        public Region()
        {
            Products = new List<Product>();
        }
    }
}
