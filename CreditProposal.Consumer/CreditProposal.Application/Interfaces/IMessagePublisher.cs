using CreditProposal.Application.DTO_s;

namespace CreditProposal.Application.Interfaces
{
    public interface IMessagePublisher
    {
        Task SendMessageQueue(CreditProposalMessage creditProposalMessage);
    }
}
