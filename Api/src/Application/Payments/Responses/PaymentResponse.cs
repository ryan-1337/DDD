namespace Application.Payments.Responses;

public class PaymentResponse
{
    public string? Id { get; set; }
    public string? ClientId { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? Timestamp { get; set; }
}