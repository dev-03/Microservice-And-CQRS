using MediatR;
using Microservice.Infrastructure.Dtos;

namespace Microservice.Infrastructure.Queries
{
    public class GetOrderByOrderNumberQuery : IRequest<OrderDto>
    {
        public string OrderNumber { get; set; }
        public GetOrderByOrderNumberQuery(string orderNumber)
        {
            if (string.IsNullOrEmpty(orderNumber))
            {
                throw new System.ArgumentException($"'{nameof(orderNumber)}' cannot be null or empty", nameof(orderNumber));
            }

            OrderNumber = orderNumber;
        }
    }
}