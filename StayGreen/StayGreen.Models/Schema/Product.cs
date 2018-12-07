using StayGreen.Models.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Product : NamedEntity<Guid>
    {
        public string Description { get; set; }
        public double Rating { get; set; }

        //Reverse navigation
        public virtual ICollection<Attachment> Pictures { get; set; }

        public Product()
        {
            Pictures = new List<Attachment>();
        }
    }
}
