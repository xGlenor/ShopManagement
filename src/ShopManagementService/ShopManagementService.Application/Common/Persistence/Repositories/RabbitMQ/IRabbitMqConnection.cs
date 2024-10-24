using RabbitMQ.Client;

namespace ShopManagementService.Application.Common.Persistence.Repositories.RabbitMQ;

public interface IRabbitMqConnection
{
    IConnection Connection { get; }
}