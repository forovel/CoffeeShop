using StayGreen.Models.Enums;
using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Coffee : NamedEntity<Guid>
    {
        public string Description { get; set; }
        public double? Prise { get; set; }
        public double? Discount { get; set; }
        public int Sour { get; set; } //Кислинка
        public int Saturation { get; set; } //Насыщенность
        public int Bitterness { get; set; } //Горечь
        public int Fortress { get; set; } //Крепость

        public CategoryType Category { get; set; }
        public CoffeeCategoryType CoffeeCategory { get; set; }
        public CoffeeRegionType CoffeeRegion { get; set; }

        //Reverse navigation
        public virtual ICollection<AttachmentCoffee> AttachmentsCoffee { get; set; }
        public virtual ICollection<CoffeePreparationCoffee> CoffeePreparationCoffee { get; set; }
        public virtual ICollection<CoffeePrise> CoffeePrises { get; set; }
        public virtual ICollection<OrderedCoffee> OrderedCoffee { get; set; }

        public Coffee()
        {
            AttachmentsCoffee = new List<AttachmentCoffee>();
            CoffeePreparationCoffee = new List<CoffeePreparationCoffee>();
            CoffeePrises = new List<CoffeePrise>();
            OrderedCoffee = new List<OrderedCoffee>();
        }
    }
}
