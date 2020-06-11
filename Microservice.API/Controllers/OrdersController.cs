using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MediatR;
using Microservice.Infrastructure.Dtos;
using Microservice.Infrastructure.Queries;
using Microservice.Infrastructure.Commands;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }
            _mediator = mediator;
        }

        [HttpGet("{orderNumber}")]
        public async Task<IActionResult> GetOrderAsync(string orderNumber)
        {
            var query = new GetOrderByOrderNumberQuery(orderNumber);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet()]
        [Route("customers")]
        public async Task<IActionResult> GetOrderByCustomerIdAsync([FromQuery] GetOrderbyCustomerIdQuery query)
        {
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}/{total}/total")]
        public async Task<IActionResult> UpdateOrderTotal([FromRoute] int id, [FromRoute] decimal total, [FromBody] UpdateOrderTotalCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            command.Total = total;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}/{status}/status")]
        public async Task<IActionResult> UpdateOrderStatus([FromRoute] int id, [FromRoute] string status, [FromBody] UpdateOrderStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            command.Status = status;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
