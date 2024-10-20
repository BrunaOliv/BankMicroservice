using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CustomerRegistration.Infra.Consumer.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly string _connectionString;
        private readonly string _queueName;

        public MessageConsumer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureServiceBus");
            _queueName = "customer";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using var client = new ServiceBusClient(_connectionString);

            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);

            while (true)
            {
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                if (receivedMessage != null)
                {
                    try
                    {
                        Console.WriteLine($"Mensagem recebida: {receivedMessage.Body}");

                        await receiver.CompleteMessageAsync(receivedMessage);
                    }
                    catch (Exception ex)
                    {
                        await receiver.AbandonMessageAsync(receivedMessage);
                        Console.WriteLine($"Erro ao processar a mensagem: {ex.Message}");
                    }
                }
            }
        }
    }
}
