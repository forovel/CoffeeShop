using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants.Coffee
{
    public static class CoffeeProcessing
    {
        static readonly IDictionary<CoffeeProcessingType, string> CoffeeProcessingTypeNames;

        static CoffeeProcessing()
        {
            CoffeeProcessingTypeNames = new Dictionary<CoffeeProcessingType, string>
            {
                { CoffeeProcessingType.Dried, CoffeeProcessingString.Dried },
                { CoffeeProcessingType.Washed, CoffeeProcessingString.Washed }
            };
        }

        public static CoffeeProcessingType? GetCoffeeProcessingTypeByName(string coffeeProcessingTypeName)
        {
            if (CoffeeProcessingTypeNames.Values.Any(x => x == coffeeProcessingTypeName))
            {
                return CoffeeProcessingTypeNames.Where(x => x.Value == coffeeProcessingTypeName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeProcessingNameByEnum(CoffeeProcessingType id)
        {
            return CoffeeProcessingTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CoffeeProcessingString
    {
        public static string Dried { get; } = "Сушенный";
        public static string Washed { get; } = "Мытый";
    }
}
