using DelegatesPractise.Domain;

namespace DelegatesPractise.Utilities
{
    public class DiscountEngine
    {
        public decimal ApplyDiscount(
            Order order,
            Predicate<Order> isEligible,
            Func<Order, decimal> discountLogic)
        {
            if (!isEligible(order))
                return order.Amount;

            return discountLogic(order);
        }
    }

}
