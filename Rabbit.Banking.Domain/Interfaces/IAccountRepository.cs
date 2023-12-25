namespace Rabbit.Banking.Domain;

public interface IAccountRepository
{
    IEnumerable<Account> GetAccounts();
    
}
