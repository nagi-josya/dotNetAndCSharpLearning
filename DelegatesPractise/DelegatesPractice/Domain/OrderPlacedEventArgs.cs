namespace DelegatesPractise.Domain
{
    public class OrderPlacedEventArgs : EventArgs
    {
        public Order Order { get; }

        public OrderPlacedEventArgs(Order order)
        {
            Order = order;
        }
    }

}
