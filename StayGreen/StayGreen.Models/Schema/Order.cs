using StayGreen.Models.Enums;
using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Order : Entity<Guid>
    {
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public OrderStatus Status { get; set; }

        //Reverse navigation
        public virtual ICollection<CoffeeOrder> CoffeeOrders { get; set; }

        public Order()
        {
            CoffeeOrders = new List<CoffeeOrder>();
        }
    }
}
