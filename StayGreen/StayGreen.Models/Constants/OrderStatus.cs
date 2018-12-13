using StayGreen.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Models.Constants
{
    public static class OrderStatus
    {
        static readonly IDictionary<OrderStatusType, string> OrderStatusTypeNames;

        static OrderStatus()
        {
            OrderStatusTypeNames = new Dictionary<OrderStatusType, string>
            {
                { OrderStatusType.InProgress, OrderStatusString.InProgress },
                { OrderStatusType.Sent, OrderStatusString.Sent },
                { OrderStatusType.Failed, OrderStatusString.Failed }
            };
        }

        public static OrderStatusType? GetOrderStatusTypeByName(string orderStatusName)
        {
            if (OrderStatusTypeNames.Values.Any(x => x == orderStatusName))
            {
                return OrderStatusTypeNames.Where(x => x.Value == orderStatusName).SingleOrDefault().Key;
            }

            return null;
        }

        public static string GetOrderStatusNameByEnum(OrderStatusType id)
        {
            return OrderStatusTypeNames.FirstOrDefault(x => x.Key == id).Value;
        }
    }

    public static class OrderStatusString
    {
        public static string InProgress { get; } = "100 грамм";
        public static string Sent { get; } = "250 грамм ";
        public static string Failed { get; } = "500 грамм";
    }
}
