using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Application;

public interface   IAccountService
{
    IEnumerable<Account> GetAccounts();
    void Transfer(AccountTransfer accountTransfer);
}
