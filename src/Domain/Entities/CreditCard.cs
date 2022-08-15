namespace Distillery.Domain.Entities;
public class CreditCard : BaseAuditableEntity
{
    public string CardNumber { get; set; }
    public float TotalCredit { get; set; }
    public float CurrentCredit { get; set; }
    public string CardOwner { get; set; }
    public List<CardBalance> CardBalances { get; set; } = new List<CardBalance>();
}
