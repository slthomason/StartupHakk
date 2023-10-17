using System.Threading.Channels;
using InMemoryEventBus.Contracts;
using InMemoryEventBus.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InMemoryEventBus.Registration;

public static class Setup
{
    public static IServiceCollection AddInMemoryEvent<T, THandler>(this IServiceCollection services)
        where THandler : class, IEventHandler<T>
    {
        // TODO: Expose configuration options and allow user to customize
        var bus = Channel.CreateUnbounded<Event<T>>(
            new UnboundedChannelOptions
            {
                AllowSynchronousContinuations = false,
            }
        );

        // typed event handler
        services.AddScoped<IEventHandler<T>, THandler>();

        // typed event producer
        services.AddSingleton(typeof(IProducer<T>), _ => new InMemoryEventBusProducer<T>(bus.Writer));

        // typed event consumer
        var consumerFactory = (IServiceProvider provider) => new InMemoryEventBusConsumer<T>(
            bus.Reader,
            provider.GetRequiredService<IServiceScopeFactory>(),
            provider.GetRequiredService<ILoggerFactory>().CreateLogger<InMemoryEventBusConsumer<T>>()
        );
        services.AddSingleton(typeof(IConsumer), consumerFactory.Invoke);
        services.AddSingleton(typeof(IConsumer<T>), consumerFactory.Invoke);

        // typed event context accessor
        services.AddSingleton(typeof(IEventContextAccessor<T>), typeof(EventContextAccessor<T>));

        return services;
    }

    public static async Task<IServiceProvider> StartConsumers(this IServiceProvider services)
    {
        var consumers = services.GetServices<IConsumer>();
        foreach (var consumer in consumers)
        {
            await consumer.Start().ConfigureAwait(false);
        }

        return services;
    }

    public static async Task<IServiceProvider> StopConsumers(this IServiceProvider services)
    {
        var consumers = services.GetServices<IConsumer>();
        foreach (var consumer in consumers)
        {
            await consumer.Stop().ConfigureAwait(false);
        }

        return services;
    }
}