using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Entities;
using Shared.Messaging;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IEventPublisher _publisher;
        public OrdersController(IEventPublisher publisher) => _publisher = publisher;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            order.Id = Guid.NewGuid();
            await _publisher.PublishAsync("orders", JsonSerializer.Serialize(order));
            return Ok(order);
        }
    }
}
