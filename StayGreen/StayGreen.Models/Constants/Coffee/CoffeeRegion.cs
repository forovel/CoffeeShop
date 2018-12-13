using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants.Coffee
{
    public static class CoffeeRegion
    {
        static readonly IDictionary<CoffeeRegionType, string> CoffeeRegionTypeNames;

        static CoffeeRegion()
        {
            CoffeeRegionTypeNames = new Dictionary<CoffeeRegionType, string>
            {
                { CoffeeRegionType.Brazil, CoffeeRegionString.Brazil }
            };
        }

        public static CoffeeRegionType? GetCoffeeRegionTypeByName(string сoffeeRegionTypeName)
        {
            if (CoffeeRegionTypeNames.Values.Any(x => x == сoffeeRegionTypeName))
            {
                return CoffeeRegionTypeNames.Where(x => x.Value == сoffeeRegionTypeName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeRegionNameByEnum(CoffeeRegionType id)
        {
            return CoffeeRegionTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CoffeeRegionString
    {
        public static string Brazil { get; } = "Бразилия";
    }
}
