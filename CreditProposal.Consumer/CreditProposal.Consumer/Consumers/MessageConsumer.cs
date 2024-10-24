﻿using Azure.Messaging.ServiceBus;
using CreditProposal.Application.Commands.CreateCreditProposal;
using CreditProposal.Configuration.Configurations;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace CreditProposal.Infra.Consumer.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly string _queueName;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;

        public MessageConsumer(IConfiguration configuration, IMediator mediator, AppSettings appSettings)
        {
            _queueName = "customer-registration-queue";
            _mediator = mediator;
            _appSettings = appSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string connectionString = _appSettings.AzureServiceBus;
            await using var client = new ServiceBusClient(connectionString);

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

        public CreateCreditProposalCommand DeserializeMessage(BinaryData message)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                return JsonSerializer.Deserialize<CreateCreditProposalCommand>(message, options);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao desserializar mensagem: {ex.Message}");
                return null;
            }
        }
    }
}

