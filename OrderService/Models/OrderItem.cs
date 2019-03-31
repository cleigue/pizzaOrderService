using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
