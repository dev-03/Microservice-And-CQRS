using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microservice.Infrastructure.Dtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microservice.Infrastructure.Mapper;
using Microservice.Infrastructure.Data;

namespace Microservice.Infrastructure.Queries
{
    public class GetOrderbyCustomerIdHandler : IRequestHandler<GetOrderbyCustomerIdQuery, List<OrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;
        public GetOrderbyCustomerIdHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext ?? throw new ArgumentNullException(nameof(orderDbContext));
        }
        public async Task<List<OrderDto>> Handle(GetOrderbyCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderDbContext.Order
                .Where(i => i.CustomerId == request.CustomerId && (i.CreatedDate > request.StartDate && i.CreatedDate < request.EndDate))
                .Select(i => i.ToDto())
                .ToListAsync();

            return result;
        }
    }
}