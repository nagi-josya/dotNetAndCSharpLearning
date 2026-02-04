using DelegatesPractise.Domain;

namespace DelegatesPractise.Subscribers
{
    public class SmsService
    {
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e)
        {
            Console.WriteLine($"📱 SMS sent for Order {e.Order.Id}");
        }
    }

}
