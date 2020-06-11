using System;

namespace Microservice.Infrastructure.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}