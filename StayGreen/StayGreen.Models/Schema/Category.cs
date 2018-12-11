using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Category : NamedEntity<Guid>
    {
        //Reverse navigation
        public virtual ICollection<Coffee> Coffee { get; set; }

        public Category()
        {
            Coffee = new List<Coffee>();
        }
    }
}
