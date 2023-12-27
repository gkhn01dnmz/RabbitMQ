using Microsoft.EntityFrameworkCore;
using Rabbit.Banking.Domain;

namespace RabbitMQ.Banking.Data
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext()
        {

        }
        public BankingDbContext(DbContextOptions options) : base(options)
        {

        }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=EFPostgres;User Id=gkhn;Password=12345;Port=5432;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Account> Accounts { get; set; }

    }
}