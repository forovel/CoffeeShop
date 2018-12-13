using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants.Coffee
{
    public static class CoffeeWeight
    {
        static readonly IDictionary<CoffeeWeightType, string> CoffeeWeightTypeNames;

        static CoffeeWeight()
        {
            CoffeeWeightTypeNames = new Dictionary<CoffeeWeightType, string>
            {
                { CoffeeWeightType.Basic, CoffeeWeightString.Basic },
                { CoffeeWeightType.Quarter, CoffeeWeightString.Quarter },
                { CoffeeWeightType.Half, CoffeeWeightString.Half },
                { CoffeeWeightType.Full, CoffeeWeightString.Full }
            };
        }

        public static CoffeeWeightType? GetCoffeeWeightTypeByName(string coffeeCategoryName)
        {
            if (CoffeeWeightTypeNames.Values.Any(x => x == coffeeCategoryName))
            {
                return CoffeeWeightTypeNames.Where(x => x.Value == coffeeCategoryName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeWeightNameByEnum(CoffeeWeightType id)
        {
            return CoffeeWeightTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CoffeeWeightString
    {
        public static string Basic { get; } = "100 грамм";
        public static string Quarter { get; } = "250 грамм ";
        public static string Half { get; } = "500 грамм";
        public static string Full { get; } = "1 кг";
    }
}
