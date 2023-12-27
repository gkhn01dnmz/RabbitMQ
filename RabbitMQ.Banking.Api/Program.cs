using MediatR;
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
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RabbitMQ.Banking.Api", Version = "v1" });
});
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQ.Banking.Api v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

