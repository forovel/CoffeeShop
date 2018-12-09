namespace StayGreen.Models.Schema
{
    public class CoffeePreparationCoffee
    {
        //Foreign keys
        public virtual CoffeePreparation CoffeePreparation { get; set; }
        public virtual Product Product { get; set; }

        public string Property { get; set; }
    }
}
