namespace Day10ofLearning.Models
{
    public class IdempotencyRecord
    {
        public string RequestHash { get; init; } = default!;
        public OrderResponse? Response { get; set; }
        public bool IsCompleted { get; set; }
    }
}
