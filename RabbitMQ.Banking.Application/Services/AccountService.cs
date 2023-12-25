using Microsoft.Extensions.Logging;
using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Application;

public class AccountService : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<AccountService> _logger;

    public AccountService(IAccountRepository accountRepository, ILogger<AccountService> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public IEnumerable<Account> GetAccounts()
    {
       return _accountRepository.GetAccounts();
    }
}
