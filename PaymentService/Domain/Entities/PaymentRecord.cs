namespace PaymentService.Domain.Entities;

public class PaymentRecord
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidAt { get; set; }
    public string Status { get; set; } = "Pending";
}