namespace ShopManagementService.Application.Common.Persistence.Repositories.RabbitMQ;

public interface IMessageReceiver
{
    void ReceiverMessage<T>(T message);
}