using MicroRabbit.Domain.Core.Bus;
using Microsoft.Extensions.Logging;
using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Application;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<AccountService> _logger;
    private readonly IEventBus _eventBus;

    public AccountService(IAccountRepository accountRepository, ILogger<AccountService> logger,IEventBus eventBus)
    {
        _accountRepository = accountRepository;
        _logger = logger;
        _eventBus=eventBus;
    }

    public IEnumerable<Account> GetAccounts()
    {
       return _accountRepository.GetAccounts();
    }

    public void Transfer(AccountTransfer accountTransfer)
    {
        var CreateTransferCommand=new CreateTransferCommand(accountTransfer.FromAccount,accountTransfer.ToAccount,accountTransfer.TransferAmount);
        _eventBus.SendCommand(CreateTransferCommand);
    }
}
