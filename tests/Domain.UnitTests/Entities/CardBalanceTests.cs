using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Distillery.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Distillery.Domain.UnitTests.Entities
{
    public class CardBalanceTests
    {
        [Fact]
        public void Entity_Created_Succeded()
        {
            var random = new Randomizer();

            var id = random.Int();
            DateTime movementDate = DateTime.Now;
            float amout = random.Float();
            int creditCardId = random.Int();
            double fee = random.Double();
            float feeAmount = random.Float();
            float paymentAmount = random.Float();

            var cardBalance = new CardBalance()
            {
                Id = id,
                MovementDate = movementDate,
                Amout = amout,
                CreditCardId = creditCardId,
                Fee = fee,
                FeeAmount = feeAmount,
                PaymentAmount = paymentAmount
            };

            cardBalance.Id.Should().Be(id);
            cardBalance.MovementDate.Should().Be(movementDate);
            cardBalance.Amout.Should().Be(amout);
            cardBalance.CreditCardId.Should().Be(creditCardId);
            cardBalance.Fee.Should().Be(fee);
            cardBalance.FeeAmount.Should().Be(feeAmount);
            cardBalance.PaymentAmount.Should().Be(paymentAmount);
        }
    }
}
