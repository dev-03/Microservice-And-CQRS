using System;
using System.Collections.Generic;
using MediatR;
using Microservice.Infrastructure.Dtos;

namespace Microservice.Infrastructure.Queries
{
    public class GetOrderbyCustomerIdQuery : IRequest<List<OrderDto>>
    {
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public GetOrderbyCustomerIdQuery(){}

        public GetOrderbyCustomerIdQuery(int customerId, DateTime startDate, DateTime endDate)
        {
            CustomerId = customerId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}