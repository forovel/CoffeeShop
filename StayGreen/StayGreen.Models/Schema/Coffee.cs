using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Coffee : NamedEntity<Guid>
    {
        public string Description { get; set; }
        public double Rating { get; set; }
        public double? Prise { get; set; }
        public string Composition { get; set; } //Состав
        public int Sour { get; set; } //Кислинка
        public int Saturation { get; set; } //Насыщенность
        public int Bitterness { get; set; } //Горечь
        public int Fortress { get; set; } //Крепость
        public Guid CategoryId { get; set; }
        public Guid CoffeeCategoryId { get; set; }
        public Guid CoffeeRegionId { get; set; }

        //Foreign keys
        public virtual Category Category { get; set; }
        public virtual CoffeeCategory CoffeeCategory { get; set; }
        public virtual CoffeeRegion CoffeeRegion { get; set; }

        //Reverse navigation
        public virtual ICollection<AttachmentCoffee> AttachmentsCoffee { get; set; }
        public virtual ICollection<CoffeePreparationCoffee> CoffeePreparationCoffee { get; set; }
        public virtual ICollection<CoffeeOrder> CoffeeOrders { get; set; }

        public Coffee()
        {
            AttachmentsCoffee = new List<AttachmentCoffee>();
            CoffeePreparationCoffee = new List<CoffeePreparationCoffee>();
            CoffeeOrders = new List<CoffeeOrder>();
        }
    }
}
