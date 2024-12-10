namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string? CardNumber { get; } = default!;
        public string? Expriration { get; } = default!;
        public string? CVV { get; } = default!;
        public int PaymentMethod {  get; } = default!;
    }
}
