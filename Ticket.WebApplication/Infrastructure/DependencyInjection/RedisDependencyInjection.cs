using StackExchange.Redis;

namespace Ticket.Application.Infrastructure.DependencyInjection;

public static class RedisDependencyInjection
{
    public static IServiceCollection AddRedisModule(this IServiceCollection services)
    {
        var connection = "localhost:6379";

        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var config = ConfigurationOptions.Parse(connection);
            config.AbortOnConnectFail = false;
            return ConnectionMultiplexer.Connect(config);
        });

        services.AddStackExchangeRedisCache(option =>
        {
            option.ConnectionMultiplexerFactory = () =>
            {
                var connectionMultiplexer =
                    services.BuildServiceProvider().GetRequiredService<IConnectionMultiplexer>();
                return Task.FromResult(connectionMultiplexer);
            };
        });

        return services;
    }
}