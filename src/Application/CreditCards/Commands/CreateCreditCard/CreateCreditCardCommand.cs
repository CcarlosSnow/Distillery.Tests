using Distillery.Application.Common.Interfaces;
using Distillery.Domain.Entities;
using Distillery.Domain.Events;
using MediatR;

namespace Distillery.Application.CreditCards.Commands.CreateCreditCard;
public class CreateCreditCardCommand : IRequest<int>
{
    public string CardNumber { get; set; }
    public float TotalCredit { get; set; }
    public string CardOwner { get; set; }
}

public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCreditCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
        var entity = new CreditCard
        {
            CardNumber = request.CardNumber,
            TotalCredit = request.TotalCredit,
            CurrentCredit = request.TotalCredit,
            CardOwner = request.CardOwner
        };

        _context.CreditCards.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
