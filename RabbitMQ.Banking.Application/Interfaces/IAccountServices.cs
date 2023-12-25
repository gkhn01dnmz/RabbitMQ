using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Application;

public interface   IAccountServices
{
    IEnumerable<Account> GetAccounts();
}
