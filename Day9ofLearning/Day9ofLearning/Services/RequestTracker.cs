namespace Day9ofLearning.Services
{
    public class RequestTracker
    {
        public Guid RequestId { get; } = Guid.NewGuid();
    }
}
