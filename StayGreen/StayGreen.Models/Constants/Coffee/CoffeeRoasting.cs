using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants.Coffee
{
    public static class CoffeeRoasting
    {
        static readonly IDictionary<CoffeeRoastingType, string> CoffeeRoastingTypeNames;

        static CoffeeRoasting()
        {
            CoffeeRoastingTypeNames = new Dictionary<CoffeeRoastingType, string>
            {
                { CoffeeRoastingType.Light, CoffeeRoastingString.Light },
                { CoffeeRoastingType.Middle, CoffeeRoastingString.Middle },
                { CoffeeRoastingType.Dark, CoffeeRoastingString.Dark }
            };
        }

        public static CoffeeRoastingType? GetCoffeeRoastingTypeByName(string coffeeRoastingTypeName)
        {
            if (CoffeeRoastingTypeNames.Values.Any(x => x == coffeeRoastingTypeName))
            {
                return CoffeeRoastingTypeNames.Where(x => x.Value == coffeeRoastingTypeName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeRoastingNameByEnum(CoffeeRoastingType id)
        {
            return CoffeeRoastingTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CoffeeRoastingString
    {
        public static string Light { get; } = "Светлая";
        public static string Middle { get; } = "Сердняя";
        public static string Dark { get; } = "Темная";
    }
}
