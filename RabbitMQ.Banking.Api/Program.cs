using Microsoft.EntityFrameworkCore;
using RabbitMQ.Banking.Data;
using RabbitMQ.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BankingDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("BankingDbConnection"));
});

DependencyContainer.RegisterServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Manually perform migrations at design-time
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<BankingDbContext>();
        dbContext.Database.Migrate();
        // Other DbContext-related operations can be performed here
    }
    catch (Exception ex)
    {
        // Handle exceptions if any occur during DbContext creation or migration
        Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

