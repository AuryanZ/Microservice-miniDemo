using Shared.Messaging;
using StackExchange.Redis;

namespace PaymentService.Infrastructure.Messaging;

public class RedisSubscriber : IEventSubscriber
{
    private readonly IConnectionMultiplexer _redis;

    public RedisSubscriber(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task SubscribeAsync(string topic, Func<string, Task> handler)
    {
        var sub = _redis.GetSubscriber();
        await sub.SubscribeAsync(topic, async (channel, message) =>
        {
            await handler(message);
        });
    }
}