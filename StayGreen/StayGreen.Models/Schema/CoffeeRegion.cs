using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class CoffeeRegion : NamedEntity<Guid>
    {
        public virtual ICollection<Coffee> Coffee { get; set; }

        public CoffeeRegion()
        {
            Coffee = new List<Coffee>();
        }
    }
}
