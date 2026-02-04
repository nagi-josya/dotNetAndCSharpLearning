using DelegatesPractise.Domain;

namespace DelegatesPractise.Subscribers
{
    public class AuditService
    {
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e)
        {
            Console.WriteLine($"📝 Audit log for Order {e.Order.Id}");
        }
    }

}
