using CreditCard.Application.Commands;
using CreditCard.Configuration.Configurations;
using CreditCard.Infra.Consumer.Consumers;
using MediatR;
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
                services.AddMediatR(typeof(CreateCreditCardCommand).Assembly);
                services.AddHostedService<MessageConsumer>();

                var appSettings = context.Configuration.Get<AppSettings>();
                services.AddSingleton(appSettings);
            })
            .Build();

        await host.RunAsync();
    }
}
