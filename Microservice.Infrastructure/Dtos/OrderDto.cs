using System;

namespace Microservice.Infrastructure.Dtos
{
    public class OrderDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}