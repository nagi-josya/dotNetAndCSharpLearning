namespace Day9ofLearning.Services
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync();
    }
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly RequestTracker _tracker;

        public PaymentService(HttpClient httpClient, RequestTracker tracker)
        {
            _httpClient = httpClient;
            _tracker = tracker;
        }

        public async Task ProcessPaymentAsync()
        {
            Console.WriteLine($"PaymentService RequestId: {_tracker.RequestId}");
            await Task.Delay(200);
        }
    }

}
