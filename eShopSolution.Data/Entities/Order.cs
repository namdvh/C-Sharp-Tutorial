using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public String ShipName { get; set; }
        public String ShipAddress { get; set; }
        public String ShipEmail { get; set; }
        public String ShipPhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser AppUser { get; set; }
    }
}
