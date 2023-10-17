namespace InMemoryEventBus.Contracts;

public record EventMetadata(string CorrelationId);
public record Event<T>(T? Data, EventMetadata? Metadata = default);


/// <summary>
/// Publishes our custom event into event broker
/// </summary>
public interface IProducer<T> : IAsyncDisposable
{
    ValueTask Publish(Event<T> @event, CancellationToken token = default);
}

/// <summary>
/// Starts processing our bus
/// We can manipulate Subscribe and Unsubscribe methods to
/// turn processing on or off
/// </summary>
public interface IConsumer : IAsyncDisposable
{
    ValueTask Start(CancellationToken token = default);

    ValueTask Stop(CancellationToken token = default);
}

public interface IConsumer<T> : IConsumer
{
}

/// <summary>
/// Handles incoming event
/// </summary>
public interface IEventHandler<in T>
{
    ValueTask Handle(T? time, CancellationToken token = default);
}

/// <summary>
/// Event metadata accessor in current async context
/// </summary>
public interface IEventContextAccessor<T>
{
    public Event<T>? Event { get; }

    void Set(Event<T> @event);
}