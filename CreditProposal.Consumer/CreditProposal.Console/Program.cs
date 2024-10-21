using CreditProposal.Application.Commands.CreateCreditProposal;
using CreditProposal.Application.Interfaces;
using CreditProposal.Configuration.Configurations;
using CreditProposal.Infra.Consumer.Consumers;
using CreditProposal.Infra.Publisher.Publishers;
using MediatR;
using Microsoft.Azure.Amqp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        
        
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddMediatR(typeof(CreateCreditProposalCommand).Assembly);
                services.AddHostedService<MessageConsumer>();
                services.AddScoped<IMessagePublisher, MessagePublisher>();

                var appSettings = context.Configuration.Get<AppSettings>();
                services.AddSingleton(appSettings);
            })
            .Build();

        await host.RunAsync();
    }
}
