namespace OrderService.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string Product { get; set; } = string.Empty;
    public decimal Total { get; set; }
}