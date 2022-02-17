using Ecommerce.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Order : Entity
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Address { get; set; }
        public OrderState State { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine : Entity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
