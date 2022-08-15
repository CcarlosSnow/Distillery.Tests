namespace Distillery.Domain.Entities;
public class CreditCard : BaseAuditableEntity
{
    public string CardNumber { get; set; }
    public float Credit { get; set; }
    public List<CardBalance> CardBalances { get; set; } = new List<CardBalance>();
}
