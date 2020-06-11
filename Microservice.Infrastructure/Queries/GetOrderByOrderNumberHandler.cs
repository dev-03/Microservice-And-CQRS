using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microservice.Infrastructure.Dtos;
using Microservice.Infrastructure.Data;
using Microservice.Infrastructure.Data.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microservice.Infrastructure.Mapper;


namespace Microservice.Infrastructure.Queries
{
    public class GetOrderbyOrderNumberHandler : IRequestHandler<GetOrderByOrderNumberQuery, OrderDto>
    {
        private readonly OrderDbContext _orderDbContext;
        public GetOrderbyOrderNumberHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext ?? throw new ArgumentNullException(nameof(orderDbContext));
        }

        public async Task<OrderDto> Handle(GetOrderByOrderNumberQuery request, CancellationToken cancellationToken)
        {

            var result = await _orderDbContext.Order.Where(i => i.OrderNumber == request.OrderNumber).FirstOrDefaultAsync();

            return result.ToDto();
        }
    }
}