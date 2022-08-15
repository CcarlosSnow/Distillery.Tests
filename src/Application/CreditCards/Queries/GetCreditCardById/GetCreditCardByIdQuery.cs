using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Distillery.Application.Common.Exceptions;
using Distillery.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Distillery.Application.CreditCards.Queries.GetCreditCardById;
public class GetCreditCardByIdQuery : IRequest<GetCreditCardByIdDto>
{
    public GetCreditCardByIdQuery(int creditCardId)
    {
        CreditCardId = creditCardId;
    }
    public int CreditCardId { get; }
}

public class GetTodosQueryHandler : IRequestHandler<GetCreditCardByIdQuery, GetCreditCardByIdDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetCreditCardByIdDto> Handle(GetCreditCardByIdQuery request, CancellationToken cancellationToken)
    {
        var creditCard = await _context.CreditCards.FindAsync(request.CreditCardId);

        if (creditCard is null)
            throw new NotFoundException($"Credit Card with Id {request.CreditCardId} does not exists.");

        var balances = await _context.CardBalances.Where(x => x.CreditCardId == request.CreditCardId)
            .OrderBy(x => x.MovementDate)
            .ProjectTo<CreditCardBalance>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new GetCreditCardByIdDto()
        {
            Summary = _mapper.Map<CreditCardSummary>(creditCard),
            Balances = balances
        };
    }
}
