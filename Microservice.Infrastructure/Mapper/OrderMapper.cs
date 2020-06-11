using System;
using Microservice.Infrastructure.Commands;
using Microservice.Infrastructure.Models;
using Microservice.Infrastructure.Dtos;

namespace Microservice.Infrastructure.Mapper
{
    public static class OrderMapper
    {
        public static Order ToModel(this CreateOrderCommand command)
        {
            var result = new Order
            {
                CustomerId = command.CustomerId,
                Total = command.Total ?? 0.00m,
                CreatedDate = DateTime.Now,
                Status = Enum.TryParse(command.Status, out OrderStatus orderStatus) ? orderStatus : 0
            };

            return result;
        }

        public static Order ToModel(this UpdateOrderStatusCommand command)
        {
            var result = new Order
            {
                Id = command.Id,
                CustomerId = command.CustomerId,
                OrderNumber = command.OrderNumber,
                Total = command.Total,
                CreatedDate = DateTime.Now,
                Status = Enum.TryParse(command.Status, out OrderStatus orderStatus) ? orderStatus : 0
            };

            return result;
        }

        public static Order ToModel(this UpdateOrderTotalCommand command)
        {
            var result = new Order
            {
                Id = command.Id,
                CustomerId = command.CustomerId,
                OrderNumber = command.OrderNumber,
                Total = command.Total,
                CreatedDate = DateTime.Now,
                Status = Enum.TryParse(command.Status, out OrderStatus orderStatus) ? orderStatus : 0
            };

            return result;
        }

        public static OrderDto ToDto(this Order order)
        {
            var result = new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderNumber = order.OrderNumber,
                Total = order.Total,
                CreatedDate = order.CreatedDate,
                Status = Enum.GetName(typeof(OrderStatus), order.Status)
            };

            return result;
        }
    }
}