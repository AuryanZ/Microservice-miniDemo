using Shared.Messaging;
using StackExchange.Redis;

namespace OrderService.Infrastructure.Messaging;

public class RedisPublisher : IEventPublisher
{
    private readonly IConnectionMultiplexer _redis;

    public RedisPublisher(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task PublishAsync(string topic, string message)
    {
        var pub = _redis.GetSubscriber();
        await pub.PublishAsync(topic, message);
    }
}