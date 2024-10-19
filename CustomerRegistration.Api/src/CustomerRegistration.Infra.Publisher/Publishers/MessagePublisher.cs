using Azure.Messaging.ServiceBus;
using CustomerRegistration.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CustomerRegistration.Infra.Publisher.Publishers
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly string _connectionString;
        private readonly string _queueName = "customer";  // Nome da fila

        public MessagePublisher(IConfiguration configuration)
        {
            // Verifica se a connection string está presente
            _connectionString = configuration.GetConnectionString("AzureServiceBus")
                               ?? throw new ArgumentNullException("AzureServiceBus connection string is not configured.");
        }

        public async Task SendMessageQueue()
        {
            var message = "teste";

            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);

            try
            {
                var messageBody = Newtonsoft.Json.JsonConvert.SerializeObject(message);

                var serviceBusMessage = new ServiceBusMessage(messageBody);

                await sender.SendMessageAsync(serviceBusMessage);
                Console.WriteLine("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar a mensagem: {ex.Message}");
                throw;
            }

        }
    }
}
