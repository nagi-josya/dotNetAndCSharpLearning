namespace Day2ofLearning
{
    public class Order
    {
        public int Id { get; }
        public MoneyRecord Price { get; }

        public Order(int id, MoneyRecord price)
        {
            Id = id;
            Price = price;
        }

        private Order withPrice(decimal newAmount, string currency)
        {
            return new Order(Id, Price with { Amount = newAmount, Currency = currency });
        }

        public Order UpdatePrice(decimal newAmount, string currency)
        {
            return withPrice(newAmount, currency);
        }
    }

}
