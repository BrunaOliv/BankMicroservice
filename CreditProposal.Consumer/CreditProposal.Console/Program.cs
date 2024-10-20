using CreditProposal.Application.Commands.CreateCreditProposal;
using CreditProposal.Configuration.Configurations;
using CreditProposal.Infra.Consumer.Consumers;
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
                // Adiciona o appsettings.json ao IConfiguration
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Registro de interfaces e implementações
                services.AddMediatR(typeof(CreateCreditProposalCommand).Assembly);
                services.AddHostedService<MessageConsumer>();

                // Registra as configurações
                var appSettings = context.Configuration.Get<AppSettings>();
                services.AddSingleton(appSettings);
            })
            .Build();

        await host.RunAsync();
    }
}
