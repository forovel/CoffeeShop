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
        public Guid CoffeeCategoryId { get; set; }

        //Foreign keys
        public virtual CoffeeCategory CoffeeCategory { get; set; }

        //Reverse navigation
        public virtual ICollection<Attachment> Pictures { get; set; }
        public virtual ICollection<CoffeeType> CoffeeTypes { get; set; }
        public virtual ICollection<CoffeePreparationCoffee> CoffeePreparationCoffee { get; set; }

        public Coffee()
        {
            Pictures = new List<Attachment>();
            CoffeeTypes = new List<CoffeeType>();
            CoffeePreparationCoffee = new List<CoffeePreparationCoffee>();
        }
    }
}
