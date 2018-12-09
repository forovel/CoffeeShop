using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class CoffeeCategory : NamedEntity<Guid>
    {
        //Reverse navigation
        public virtual ICollection<Coffee> Coffee { get; set; }

        public CoffeeCategory()
        {
            Coffee = new List<Coffee>();
        }
    }
}
