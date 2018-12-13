using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants.Coffee
{
    public class CoffeeGrains
    {
        static readonly IDictionary<CoffeeGrainsType, string> CoffeeGrainsTypeNames;

        static CoffeeGrains()
        {
            CoffeeGrainsTypeNames = new Dictionary<CoffeeGrainsType, string>
            {
                { CoffeeGrainsType.Cereal, CoffeeGrainsString.Cereal },
                { CoffeeGrainsType.Milled, CoffeeGrainsString.Milled }
            };
        }

        public static CoffeeGrainsType? GetCoffeeGrainsTypeByName(string сoffeeGrainsTypeName)
        {
            if (CoffeeGrainsTypeNames.Values.Any(x => x == сoffeeGrainsTypeName))
            {
                return CoffeeGrainsTypeNames.Where(x => x.Value == сoffeeGrainsTypeName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeGrainsNameByEnum(CoffeeGrainsType id)
        {
            return CoffeeGrainsTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CoffeeGrainsString
    {
        public static string Cereal { get; } = "Зерновой";
        public static string Milled { get; } = "Молотый";
    }
}
