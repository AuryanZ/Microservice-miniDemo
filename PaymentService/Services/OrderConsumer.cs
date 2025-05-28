using Shared.Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace PaymentService.Services;

public class OrderConsumer : BackgroundService
{
    private readonly IEventSubscriber _subscriber;
    private readonly ILogger<OrderConsumer> _logger;

    public OrderConsumer(IEventSubscriber subscriber, ILogger<OrderConsumer> logger)
    {
        _subscriber = subscriber;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _subscriber.SubscribeAsync("orders", async message =>
        {
            var order = JsonSerializer.Deserialize<OrderDto>(message);
            _logger.LogInformation($"Received order {order?.Id} for product: {order?.Product}");

            await Task.Delay(500); // 模拟扣款
            _logger.LogInformation($"Processed payment for order {order?.Id}");
        });
    }
}

public record OrderDto(Guid Id, string Product, decimal Total);