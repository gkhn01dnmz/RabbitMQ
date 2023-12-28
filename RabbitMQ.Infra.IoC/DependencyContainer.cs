using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infro.Bus;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Banking.Domain;
using RabbitMQ.Banking.Application;
using RabbitMQ.Banking.Data;

namespace RabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void  RegisterServices(IServiceCollection services)
        {
            //Doman Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data

            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<BankingDbContext>();
        }
    }
}
