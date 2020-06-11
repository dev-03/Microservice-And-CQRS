using System;
using System.Collections.Generic;
using MediatR;
using Microservice.Infrastructure.Dtos;
using Microservice.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microservice.Infrastructure.Mapper;
using Microservice.Infrastructure.Data;
using Microservice.Infrastructure.Data.Repositories;

namespace Microservice.Infrastructure.Commands
{
    public class UpdateOrderTotalHandler : IRequestHandler<UpdateOrderTotalCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UnitOfWork _unitOfWork;
        public UpdateOrderTotalHandler(IOrderRepository orderRepository, UnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<OrderDto> Handle(UpdateOrderTotalCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToModel();
            _orderRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();

            var response = model.ToDto();
            return response;
        }
    }
}