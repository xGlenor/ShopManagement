using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using ShopManagementService.Application.Common.Persistence.Repositories.RabbitMQ;

namespace ShopManagementService.Application.Common.RabbitMQ;

public class RabbitMqSender: IMessageSender
{
    private readonly IRabbitMqConnection _connection;

    public RabbitMqSender(IRabbitMqConnection connection)
    {
        _connection = connection;
    }

    public async void SendMessage<T>(T message)
    {
        using var channel = await _connection.Connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(typeof(T).Name, exclusive: false);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);
        
        await channel.BasicPublishAsync(exchange: "", routingKey: typeof(T).Name, body: body);
    }
    
    
}