using CreditProposal.Domain.Enuns;

namespace CreditProposal.Application.DTO_s
{
    public class CreditProposalMessage
    {
        public CreditProposalMessage(Guid customerId, List<CreditCardMessage> creditCards)
        {
            CustomerId = customerId;
            CreditCards = creditCards;
        }

        public Guid CustomerId { get; set; }
        public List<CreditCardMessage> CreditCards { get; set; }
        

        public class CreditCardMessage
        {
            public CreditCardMessage(Guid cardId, CardType requestedCardType, CardStatus status, decimal? limitApprovad)
            {
                CardId = cardId;
                RequestedCardType = requestedCardType;
                Status = status;
                LimitApprovad = limitApprovad;
            }

            public Guid CardId { get; set; }
            public CardType RequestedCardType { get; set; }
            public CardStatus Status { get; set; }
            public decimal? LimitApprovad { get; set; }
        }

    }
}
