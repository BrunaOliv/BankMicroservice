using Azure.Messaging.ServiceBus;
using CustomerRegistration.Application.DTOs;
using CustomerRegistration.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CustomerRegistration.Infra.Publisher.Publishers
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly string _connectionString;
        private readonly string _queueName = "customer";

        public MessagePublisher(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureServiceBus")
                               ?? throw new ArgumentNullException("AzureServiceBus connection string is not configured.");
        }

        public async Task SendMessageQueue(CustomerMessage customerMessage)
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);

            try
            {
                var messageBody = Newtonsoft.Json.JsonConvert.SerializeObject(customerMessage);

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
