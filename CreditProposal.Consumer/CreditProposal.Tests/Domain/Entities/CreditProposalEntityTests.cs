using CreditProposal.Domain.Entities;
using CreditProposal.Domain.Enuns;
using FluentAssertions;

namespace CreditProposal.Tests.Domain.Entities
{
    public class CreditProposalEntityTests
    {
        [Fact]
        public void GenerateCreditProposal_Should_Return_PlatinumGoldSilver_When_HighIncomeAndGoodScore()
        {
            // Arrange
            var score = 800;
            var income = 16000m;
            var employmentDuration = 12;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            proposal.Cards.Should().HaveCount(3)
                .And.Contain(c => c.CardType == CardType.Platinum)
                .And.Contain(c => c.CardType == CardType.Gold)
                .And.Contain(c => c.CardType == CardType.Silver);
        }

        [Fact]
        public void GenerateCreditProposal_Should_Return_GoldSilver_When_MediumIncomeAndValidScore()
        {
            // Arrange
            var score = 700;
            var income = 10000m;
            var employmentDuration = 6;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            proposal.Cards.Should().HaveCount(2)
                .And.Contain(c => c.CardType == CardType.Gold)
                .And.Contain(c => c.CardType == CardType.Silver);
        }

        [Fact]
        public void GenerateCreditProposal_Should_Return_Silver_When_LowIncomeAndValidScore()
        {
            // Arrange
            var score = 300;
            var income = 4000m;
            var employmentDuration = 3;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            proposal.Cards.Should().HaveCount(1)
                .And.Contain(c => c.CardType == CardType.Silver);
        }

        [Fact]
        public void GenerateCreditProposal_Should_Return_Empty_When_ScoreIsBelowMinimum()
        {
            // Arrange
            var score = 200;
            var income = 6000m;
            var employmentDuration = 6;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            proposal.Cards.Should().BeEmpty();
        }

        [Fact]
        public void CalculateLimit_Should_Return_FullLimit_When_ScoreAndEmploymentDurationAreHigh()
        {
            // Arrange
            var score = 800;
            var income = 20000m;
            var employmentDuration = 12;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            var platinumCard = proposal.Cards
                .SingleOrDefault(c => c.CardType == CardType.Platinum);

            platinumCard.Should().NotBeNull("Platinum card should be present");
            platinumCard?.MaxLimit.Should().Be(100000m, "limit should be 50000 for high income and good score");
        }

        [Fact]
        public void CalculateLimit_Should_Return_80PercentLimit_When_ScoreAndEmploymentDurationAreModerate()
        {
            // Arrange
            var score = 750;
            var income = 20000m;
            var employmentDuration = 6;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            var platinumCard = proposal.Cards.SingleOrDefault(c => c.CardType == CardType.Platinum);

            platinumCard.Should().NotBeNull("Platinum card should be present");
            platinumCard!.MaxLimit.Should().Be(80000m, "80% of limit should be given for moderate score and employment duration");
        }

        [Fact]
        public void CalculateLimit_Should_Return_50PercentLimit_When_ScoreOrEmploymentDurationAreLow()
        {
            // Arrange
            var score = 600;
            var income = 20000m;
            var employmentDuration = 3;

            // Act
            var proposal = new CreditProposalEntity(score, income, employmentDuration);

            // Assert
            var platinumCard = proposal.Cards.SingleOrDefault(c => c.CardType == CardType.Platinum);

            platinumCard.Should().NotBeNull("Platinum card should be present");
            platinumCard!.MaxLimit.Should().Be(50000m, "50% of limit should be given for low score or short employment duration");
        }

    }
}
