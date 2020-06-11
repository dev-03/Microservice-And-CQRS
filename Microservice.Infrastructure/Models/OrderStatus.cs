using System;

namespace Microservice.Infrastructure.Models
{
    [Flags]
    public enum OrderStatus
    {
        Pending = 0,
        Ordered = 1,
        Billed = 2,
        Shipped = 4,
        Delivered = 8,
        Submitted = Billed | Shipped | Delivered
    }
}