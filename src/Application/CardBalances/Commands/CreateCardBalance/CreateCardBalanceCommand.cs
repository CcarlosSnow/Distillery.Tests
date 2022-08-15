using Distillery.Application.Common.Exceptions;
using Distillery.Application.Common.Interfaces;
using Distillery.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

    public CreateCardBalancesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCardBalanceCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _context.CreditCards.FindAsync(request.CreditCardId);

        if (creditCard is null)
            throw new NotFoundException($"Credit Card with Id {request.CreditCardId} does not exists.");

        if (creditCard.CurrentCredit < request.Amout)
            throw new BusinessRuleException($"Credit Card with Id {request.CreditCardId} does not have enought credit.");

        var entity = new CardBalance
        {
            MovementDate = request.MovementDate,
            Amout = request.Amout,
            CreditCardId = request.CreditCardId,
        };

        creditCard.CurrentCredit -= request.Amout;

        _context.CardBalances.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
