using System;
using System.Collections.Generic;
using MediatR;
using Microservice.Infrastructure.Dtos;
using Microservice.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Infrastructure.Commands
{
    public class UpdateOrderTotalCommand : IRequest<OrderDto>
    {
        [Required]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

        public UpdateOrderTotalCommand() { }
        public UpdateOrderTotalCommand(long id, long customerId, string orderNumber, decimal total, DateTime createdDate, string status)
        {
            Id = id;
            CustomerId = customerId;
            OrderNumber = orderNumber;
            Total = total;
            CreatedDate = createdDate;
            Status = status;
        }
    }
}