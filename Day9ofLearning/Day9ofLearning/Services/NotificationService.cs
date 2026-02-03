namespace Day9ofLearning.Services
{
    public interface INotificationService
    {
        void Notify();
    }

    public class NotificationService : INotificationService
    {
        private readonly RequestTracker _tracker;

        public NotificationService(RequestTracker tracker)
        {
            _tracker = tracker;
        }

        public void Notify()
        {
            Console.WriteLine($"Notification RequestId: {_tracker.RequestId}");
        }
    }

}
