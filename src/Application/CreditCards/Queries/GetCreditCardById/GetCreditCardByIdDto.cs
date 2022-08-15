using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distillery.Application.Common.Mappings;
using Distillery.Domain.Entities;

namespace Distillery.Application.CreditCards.Queries.GetCreditCardById;
public class GetCreditCardByIdDto
{
    public CreditCardSummary Summary { get; set; }
    public List<CreditCardBalance> Balances { get; set; }
}

public class CreditCardSummary : IMapFrom<CreditCard>
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public float TotalCredit { get; set; }
    public float CurrentCredit { get; set; }
    public string CardOwner { get; set; }
}

public class CreditCardBalance : IMapFrom<CardBalance>
{
    public DateTime MovementDate { get; set; }
    public float Amout { get; set; }
}
