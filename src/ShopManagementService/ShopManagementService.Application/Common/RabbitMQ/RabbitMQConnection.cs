using RabbitMQ.Client;
using ShopManagementService.Application.Common.Persistence.Repositories.RabbitMQ;

namespace ShopManagementService.Application.Common.RabbitMQ;

public class RabbitMQConnection : IRabbitMqConnection, IDisposable
{
    private IConnection? _connection;

    public IConnection Connection => _connection;

    public RabbitMQConnection()
    {
        InitializeConnection();
    }

    private async void InitializeConnection()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _connection = await factory.CreateConnectionAsync();
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}