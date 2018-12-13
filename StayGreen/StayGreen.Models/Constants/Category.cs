using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants
{
    public static class Category
    {
        static readonly IDictionary<CategoryType, string> CategoryTypeNames;

        static Category()
        {
            CategoryTypeNames = new Dictionary<CategoryType, string>
            {
                { CategoryType.Coffee, CategoryString.Coffee }
            };
        }

        public static CategoryType? GetCoffeeRoastingTypeByName(string coffeeRoastingTypeName)
        {
            if (CategoryTypeNames.Values.Any(x => x == coffeeRoastingTypeName))
            {
                return CategoryTypeNames.Where(x => x.Value == coffeeRoastingTypeName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetCoffeeCategoryNameByEnum(CategoryType id)
        {
            return CategoryTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class CategoryString
    {
        public static string Coffee { get; } = "Кофе";
    }
}
