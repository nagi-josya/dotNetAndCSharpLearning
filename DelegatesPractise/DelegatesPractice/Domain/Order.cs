namespace DelegatesPractise.Domain
{
    public class Order
    {
        public int Id { get; }
        public decimal Amount { get; }

        public Order(int id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }
    }

}
