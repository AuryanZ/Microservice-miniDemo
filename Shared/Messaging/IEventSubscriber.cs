namespace Shared.Messaging;

public interface IEventSubscriber
{
    Task SubscribeAsync(string topic, Func<string, Task> handler);
}