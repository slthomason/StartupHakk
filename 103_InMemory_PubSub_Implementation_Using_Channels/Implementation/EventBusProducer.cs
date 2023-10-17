using System.Threading.Channels;
using InMemoryEventBus.Contracts;

namespace InMemoryEventBus.Implementation;

internal sealed class InMemoryEventBusProducer<T> : IProducer<T>
{
    private readonly ChannelWriter<Event<T>> _bus;

    public InMemoryEventBusProducer(ChannelWriter<Event<T>> bus)
    {
        _bus = bus;
    }

    public async ValueTask Publish(Event<T> @event, CancellationToken token = default)
    {
        await _bus.WriteAsync(@event, token).ConfigureAwait(false);
    }

    public ValueTask DisposeAsync()
    {
        _bus.TryComplete();

        return ValueTask.CompletedTask;
    }
}