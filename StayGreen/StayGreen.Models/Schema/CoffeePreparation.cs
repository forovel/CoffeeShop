using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class CoffeePreparation : NamedEntity<Guid>
    {
        public Guid? AttachmentId { get; set; }

        //Foreign keys
        public virtual Attachment Attachment { get; set; }

        //Reverse navigation
        public virtual ICollection<CoffeePreparationCoffee> CoffeePreparationCoffee { get; set; }

        public CoffeePreparation()
        {
            CoffeePreparationCoffee = new List<CoffeePreparationCoffee>();
        }
    }
}
