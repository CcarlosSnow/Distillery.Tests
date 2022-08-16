using Bogus;
using Distillery.Application.Common.Interfaces;
using Distillery.Application.CreditCards.Commands.CreateCreditCard;
using FluentAssertions;
using Moq;
using UniTests.Shared;
using Xunit;

namespace Distillery.Application.UnitTests.CreditCards.Commands.CreateCreditCard
{
    
    public class CreateCreditCardCommandTests
    {
        [Fact]
        public void Create_Command_Succeded()
        {
            var random = new Randomizer();
            var cardNumber = random.AlphaNumeric(15);
            var totalCredit = random.Float();
            var cardOwner = random.AlphaNumeric(20);

            var command = new CreateCreditCardCommand(cardNumber, totalCredit, cardOwner);

            command.CardNumber.Should().Be(cardNumber);
            command.TotalCredit.Should().Be(totalCredit);
            command.CardOwner.Should().Be(cardOwner);
        }


        [Fact]
        public async Task Command_Handle_Succeded()
        {
            var random = new Randomizer();
            var cardNumber = random.AlphaNumeric(15);
            var totalCredit = random.Float();
            var cardOwner = random.AlphaNumeric(20);
            
            var applicationDbContextMock = new Mock<IApplicationDbContext>();
            applicationDbContextMock.Setup(x => x.CreditCards).Returns(AppEntityFaker.GetDbSetCreditCard().Generate());
            var command = new CreateCreditCardCommand(cardNumber, totalCredit, cardOwner);
            var handler = new CreateCreditCardCommandHandler(applicationDbContextMock.Object);

            var result = await handler.Handle(command, default);

            result.Should().BeOfType(typeof(int));
            applicationDbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
