using DelegatesPractise.Domain;

namespace DelegatesPractise.Subscribers
{
    public class EmailService
    {
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e)
        {
            Console.WriteLine($"📧 Email sent for Order {e.Order.Id}");
        }
    }

}
