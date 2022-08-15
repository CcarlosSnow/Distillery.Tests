using Distillery.Application.Common.Exceptions;
using Distillery.Application.Common.Interfaces;
using Distillery.Domain.Entities;
using MediatR;

namespace Distillery.Application.CardBalances.Commands.CreateCardBalance;
public class CreateCardBalanceCommand : IRequest<int>
{
    public DateTime MovementDate { get; set; }
    public float Amout { get; set; }
    public int CreditCardId { get; set; }
}

public class CreateCardBalancesCommandHandler : IRequestHandler<CreateCardBalanceCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IPaymentFee _paymentFee;

    public CreateCardBalancesCommandHandler(IApplicationDbContext context, IPaymentFee paymentFee)
    {
        _context = context;
        _paymentFee = paymentFee;
    }

    public async Task<int> Handle(CreateCardBalanceCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _context.CreditCards.FindAsync(request.CreditCardId);

        if (creditCard is null)
            throw new NotFoundException($"Credit Card with Id {request.CreditCardId} does not exists.");

        if (creditCard.CurrentCredit < request.Amout)
            throw new BusinessRuleException($"Credit Card with Id {request.CreditCardId} does not have enought credit.");

        var fee = _paymentFee.GetFee();
        var feeAmount = (request.Amout * fee) / 100;
        var paymentAmount = request.Amout + feeAmount;

        var entity = new CardBalance
        {
            MovementDate = request.MovementDate,
            Amout = request.Amout,
            CreditCardId = request.CreditCardId,
            Fee = fee,
            FeeAmount = (float)feeAmount,
            PaymentAmount = (float)paymentAmount,
        };

        creditCard.CurrentCredit -= request.Amout;

        _context.CardBalances.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
