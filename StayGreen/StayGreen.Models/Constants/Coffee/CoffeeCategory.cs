using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants.Coffee
{
    public static class CoffeeCategory
    {
        static readonly IDictionary<CoffeeCategoryType, string> CoffeeCategoryTypeNames;

        static CoffeeCategory()
        {
            CoffeeCategoryTypeNames = new Dictionary<CoffeeCategoryType, string>
            {
                { CoffeeCategoryType.Arabica, CoffeCategoryString.Arabica }
            };
        }

        public static CoffeeCategoryType? GetCoffeeCategoryTypeByName(string coffeeCategoryName)
        {
            if (CoffeeCategoryTypeNames.Values.Any(x => x == coffeeCategoryName))
            {
                return CoffeeCategoryTypeNames.Where(x => x.Value == coffeeCategoryName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeCategoryNameByEnum(CoffeeCategoryType id)
        {
            return CoffeeCategoryTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CoffeCategoryString
    {
        public static string Arabica { get; } = "Арабика";
    }
}
