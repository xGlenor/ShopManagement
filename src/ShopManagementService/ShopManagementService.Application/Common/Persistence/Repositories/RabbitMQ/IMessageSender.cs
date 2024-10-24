namespace ShopManagementService.Application.Common.Persistence.Repositories.RabbitMQ;

public interface IMessageSender
{
    void SendMessage<T>(T message);
}