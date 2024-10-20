using Azure.Messaging.ServiceBus;
using CustomerRegistration.Application.Commands.UpdateCustomerCreditCard;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace CustomerRegistration.Infra.Consumer.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly string _connectionString;
        private readonly string _queueName;
        private readonly IMediator _mediator;

        public MessageConsumer(IConfiguration configuration, IMediator mediator)
        {
            _connectionString = configuration.GetConnectionString("AzureServiceBus");
            _queueName = "creditcard";
            _mediator = mediator;
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

                        var command = DeserializeMessage(receivedMessage.Body);

                        await _mediator.Send(command);

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

        public UpdateCustomerCreditCardCommand DeserializeMessage(BinaryData message)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                return JsonSerializer.Deserialize<UpdateCustomerCreditCardCommand>(message, options);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao desserializar mensagem: {ex.Message}");
                return null;
            }
        }


    }
}
