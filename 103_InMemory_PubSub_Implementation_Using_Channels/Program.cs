using InMemoryEventBus;
using InMemoryEventBus.Contracts;
using InMemoryEventBus.Registration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddLogging(b => b.AddSimpleConsole());

// Register bus services
services.AddInMemoryEvent<int, OrderNumberEventHandler>();
services.AddInMemoryEvent<OrderEvent, OrderPlacedEventHandler>();
services.AddInMemoryEvent<OrderEvent, TrackUserOrderItemsEventHandler>();

var provider = services.BuildServiceProvider();
var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger("Program");

var orderNumberProducer = provider.GetRequiredService<IProducer<int>>();
var orderProducer = provider.GetRequiredService<IProducer<OrderEvent>>();
var publishEventsFn = async (int i) =>
{
    var metadata = new EventMetadata(Guid.NewGuid().ToString());

    var orderNumberTask = new Event<int>(i, metadata);
    var counterTask = new Event<OrderEvent>(new OrderEvent(i, i, i), metadata);

    await orderNumberProducer.Publish(orderNumberTask).ConfigureAwait(false);
    await orderProducer.Publish(counterTask).ConfigureAwait(false);
};

await provider.StartConsumers();

for (var i = 0; i < 3; i++)
{
    await publishEventsFn.Invoke(i);
}

// allow events to process and stop consumers
await Task.Delay(TimeSpan.FromSeconds(3));
await provider.StopConsumers();
logger.LogInformation("\nConsumers stopped\n");

// bus some more events while the consumers are stopped
for (var i = 3; i < 8; i++)
{
    await publishEventsFn.Invoke(i);
    logger.LogInformation("EventBusd {0}, but consumers are not running yet", i);
}

// start the consumers
logger.LogInformation("\nConsumers started\n");
await provider.StartConsumers();
await Task.Delay(TimeSpan.FromSeconds(3));