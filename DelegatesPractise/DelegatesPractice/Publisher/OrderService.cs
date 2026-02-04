using DelegatesPractise.Domain;

namespace DelegatesPractise.Publisher
{
    public class OrderService
    {
        public event EventHandler<OrderPlacedEventArgs> OrderPlaced;

        public void PlaceOrder(Order order)
        {
            Console.WriteLine($"Order {order.Id} placed");

            OrderPlaced?.Invoke(
                this,
                new OrderPlacedEventArgs(order)
            );
        }
    }

}
