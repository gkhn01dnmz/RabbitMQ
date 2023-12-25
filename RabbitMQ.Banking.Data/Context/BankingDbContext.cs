using Microsoft.EntityFrameworkCore;
using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Data;

public class BankingDbContext: DbContext
{
public BankingDbContext(DbContextOptions options) : base(options)
{
    
}
    public DbSet<Account> Accounts { get; set; }

}
