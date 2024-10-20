using CreditProposal.Domain.Enuns;

namespace CreditProposal.Application.DTO_s
{
    public class CreditProposalMessage
    {
        public CreditProposalMessage(int customerId, List<CreditCardMessage> creditCards)
        {
            CustomerId = customerId;
            CreditCards = creditCards;
        }

        public int CustomerId { get; set; }
        public List<CreditCardMessage> CreditCards { get; set; }
        

        public class CreditCardMessage
        {
            public CreditCardMessage(CardType requestedCardType, CardStatus status, decimal limitApprovad)
            {
                RequestedCardType = requestedCardType;
                Status = status;
                LimitApprovad = limitApprovad;
            }

            public CardType RequestedCardType { get; set; }
            public CardStatus Status { get; set; }
            public decimal LimitApprovad { get; set; }
        }

    }
}
