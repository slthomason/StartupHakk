using InMemoryEventBus.Contracts;
using Microsoft.Extensions.Logging;

namespace InMemoryEventBus;

public sealed record OrderEvent(int OrderNumber, int ItemCount, int UserId);

public sealed class OrderPlacedEventHandler : IEventHandler<OrderEvent>
{
    private readonly ILogger<OrderPlacedEventHandler> _logger;

    public OrderPlacedEventHandler(ILogger<OrderPlacedEventHandler> logger)
    {
        _logger = logger;
    }

    public ValueTask Handle(OrderEvent time, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Order {0} has been placed", time.OrderNumber);
        return ValueTask.CompletedTask;
    }
}

public sealed class TrackUserOrderItemsEventHandler : IEventHandler<OrderEvent>
{
    private readonly ILogger<TrackUserOrderItemsEventHandler> _logger;

    public TrackUserOrderItemsEventHandler(ILogger<TrackUserOrderItemsEventHandler> logger)
    {
        _logger = logger;
    }

    public ValueTask Handle(OrderEvent? time, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("User {0} has ordered {1} items", time.UserId, time.ItemCount);
        return ValueTask.CompletedTask;
    }
}

public sealed class OrderNumberEventHandler : IEventHandler<int>
{
    private readonly IEventContextAccessor<int> _ctx;
    private readonly ILogger<OrderNumberEventHandler> _logger;

    public OrderNumberEventHandler(IEventContextAccessor<int> ctx, ILogger<OrderNumberEventHandler> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }

    public ValueTask Handle(int orderNumber, CancellationToken cancellationToken = default)
    {
        var correlationId = _ctx.Event.Metadata!.CorrelationId;
        _logger.LogInformation("Order number {0} invoked with correlation id {1}", orderNumber, correlationId);
        return ValueTask.CompletedTask;
    }
}