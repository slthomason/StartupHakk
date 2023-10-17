using System.Threading.Channels;
using InMemoryEventBus.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#pragma warning disable CS4014

namespace InMemoryEventBus.Implementation;

internal sealed class InMemoryEventBusConsumer<T> : IConsumer<T>
{
    private readonly ChannelReader<Event<T>> _bus;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<InMemoryEventBusConsumer<T>> _logger;

    private CancellationTokenSource? _stoppingToken;

    public InMemoryEventBusConsumer(
        ChannelReader<Event<T>> bus,
        IServiceScopeFactory scopeFactory,
        ILogger<InMemoryEventBusConsumer<T>> logger
    )
    {
        _logger = logger;
        _bus = bus;
        _scopeFactory = scopeFactory;
    }

    public async ValueTask Start(CancellationToken token = default)
    {
        EnsureStoppingTokenIsCreated();

        // factory new scope so we can use it as execution context
        await using var scope = _scopeFactory.CreateAsyncScope();

        // retrieve scoped dependencies
        var handlers = scope.ServiceProvider.GetServices<IEventHandler<T>>().ToList();
        var contextAccessor = scope.ServiceProvider.GetRequiredService<IEventContextAccessor<T>>();

        if (handlers.FirstOrDefault() is null)
        {
            _logger.LogDebug("No handlers defined for event of {type}", typeof(T).Name);
            return;
        }

        Task.Run(
            async () => await StartProcessing(handlers, contextAccessor).ConfigureAwait(false),
            _stoppingToken!.Token
        ).ConfigureAwait(false);
    }

    private void EnsureStoppingTokenIsCreated()
    {
        if (_stoppingToken is not null && _stoppingToken.IsCancellationRequested == false)
        {
            _stoppingToken.Cancel();
        }

        _stoppingToken = new CancellationTokenSource();
    }

    internal async ValueTask StartProcessing(List<IEventHandler<T>> handlers, IEventContextAccessor<T> contextAccessor)
    {
        var continuousChannelIterator = _bus.ReadAllAsync(_stoppingToken!.Token)
            .WithCancellation(_stoppingToken.Token)
            .ConfigureAwait(false);

        await foreach (var task in continuousChannelIterator)
        {
            if (_stoppingToken.IsCancellationRequested)
                break;

            // invoke handlers in parallel
            await Parallel.ForEachAsync(handlers, _stoppingToken.Token,
                async (handler, scopedToken) => await ExecuteHandler(handler, task, contextAccessor, scopedToken)
                    .ConfigureAwait(false)
            ).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Executes the handler in async scope
    /// </summary>
    internal ValueTask ExecuteHandler(IEventHandler<T> handler, Event<T> task, IEventContextAccessor<T> ctx, CancellationToken token)
    {
        ctx.Set(task); // set metadata and begin scope
        using var logScope = _logger.BeginScope(task.Metadata ?? new EventMetadata(Guid.NewGuid().ToString()));

        Task.Run(
            async () => await handler.Handle(task.Data, token), token
        ).ConfigureAwait(false);

        return ValueTask.CompletedTask;
    }

    public async ValueTask Stop(CancellationToken _ = default)
    {
        await DisposeAsync().ConfigureAwait(false);
    }

    public async ValueTask DisposeAsync()
    {
        _stoppingToken?.Cancel();
    }
}