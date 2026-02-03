namespace Day9ofLearning.Services
{
    public interface IOrderService
    {
        Task PlaceOrderAsync();
    }

    public class OrderService : IOrderService
    {
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;
        private readonly ICacheService _cacheService;
        private readonly RequestTracker _tracker;

        public OrderService(
            IPaymentService paymentService,
            INotificationService notificationService,
            ICacheService cacheService,
            RequestTracker tracker)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
            _cacheService = cacheService;
            _tracker = tracker;
        }

        public async Task PlaceOrderAsync()
        {
            Console.WriteLine($"OrderService RequestId: {_tracker.RequestId}");

            await _paymentService.ProcessPaymentAsync();
            _notificationService.Notify();

            _cacheService.Set("lastOrder", DateTime.Now.ToString());
        }
    }

}
