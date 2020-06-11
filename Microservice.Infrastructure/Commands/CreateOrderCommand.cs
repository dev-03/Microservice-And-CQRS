using System;
using System.Collections.Generic;
using MediatR;
using Microservice.Infrastructure.Dtos;
using Microservice.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Infrastructure.Commands
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        [Required]
        public int CustomerId { get; set; }
        public decimal? Total { get; set; }
        [Required]
        public string Status { get; set; } = OrderStatus.Pending.ToString("d");

        public CreateOrderCommand() { }

        public CreateOrderCommand(int customerId, decimal? total, string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentException($"'{nameof(status)}' cannot be null or empty", nameof(status));
            }

            CustomerId = customerId;
            Total = total;
            Status = status;
        }
    }
}