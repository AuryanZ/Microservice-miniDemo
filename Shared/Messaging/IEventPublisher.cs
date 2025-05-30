﻿namespace Shared.Messaging;

public interface IEventPublisher
{
    Task PublishAsync(string topic, string message);
}