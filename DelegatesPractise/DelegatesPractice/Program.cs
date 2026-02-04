using DelegatesPractise.Domain;
using DelegatesPractise.Publisher;
using DelegatesPractise.Subscribers;
using DelegatesPractise.Utilities;

var orderService = new OrderService();

var email = new EmailService();
var sms = new SmsService();
var audit = new AuditService();

orderService.OrderPlaced += email.OnOrderPlaced;
orderService.OrderPlaced += sms.OnOrderPlaced;
orderService.OrderPlaced += audit.OnOrderPlaced;

orderService.PlaceOrder(new Order(101, 5000));

var engine = new DiscountEngine();

decimal finalAmount = engine.ApplyDiscount(
    new Order(102, 12000),
    o => o.Amount > 10000,        // Predicate
    o => o.Amount * 0.9m          // Func
);

Console.WriteLine($"Final Amount: {finalAmount}");
