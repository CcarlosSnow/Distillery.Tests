namespace Distillery.Domain.Entities;
public class CardBalance : BaseAuditableEntity
{
    public DateTime MovementDate { get; set; }
    public float Amout { get; set; }
    public int CreditCardId { get; set; }
    public CreditCard CreditCard { get; set; }
    public double Fee { get; set; }
    public float FeeAmount { get; set; }
    public float PaymentAmount { get; set; }
}
