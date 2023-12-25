using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Data;

public class AccountRepository : IAccountRepository
{

    private readonly BankingDbContext _context;

    public AccountRepository(BankingDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _context.Accounts;
    }
}
