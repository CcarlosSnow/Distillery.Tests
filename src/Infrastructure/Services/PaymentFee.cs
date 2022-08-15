using Distillery.Application.Common.Interfaces;

namespace Distillery.Infrastructure.Services;
public class PaymentFee : IPaymentFee
{
    private double LastPaymentFee = 0;
    public double GetFee()
    {
        Random random = new Random();
        double max = 2, min = 0.1;
        double randomValue = (random.NextDouble() * (max - min) + min);

        if (LastPaymentFee == 0)
            LastPaymentFee = randomValue;
        else
            LastPaymentFee = LastPaymentFee * randomValue;

        return LastPaymentFee;
    }
}
