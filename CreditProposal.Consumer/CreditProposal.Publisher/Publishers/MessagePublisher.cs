using Azure.Messaging.ServiceBus;
using CreditProposal.Application.DTO_s;
using CreditProposal.Application.Interfaces;
using CreditProposal.Configuration.Configurations;

namespace CreditProposal.Infra.Publisher.Publishers
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly string _connectionString;
        private readonly string _queueName = "credit-proposal-queue";
        private readonly AppSettings _appSettings;

        public MessagePublisher(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task SendMessageQueue(CreditProposalMessage creditProposalMessage)
        {
            string connectionString = _appSettings.AzureServiceBus;
            await using var client = new ServiceBusClient(connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);

            try
            {
                var messageBody = Newtonsoft.Json.JsonConvert.SerializeObject(creditProposalMessage);

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
