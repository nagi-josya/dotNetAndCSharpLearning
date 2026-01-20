using Day2ofLearning;

var m1 = new MoneyClass(100, "USD");
var m2 = m1;

m2.Amount = 200;

Console.WriteLine(m1.Amount); // ?

Console.WriteLine("==========================");

var m3 = new MoneyStruct(100, "USD");
var m4 = m3;

m4 = new MoneyStruct(200, "USD");

Console.WriteLine(m3.Amount); // ?
Console.WriteLine(m3.Equals(m4)); // ?

Console.ReadLine();

Console.WriteLine("==========================");

var m5 = new MoneyRecord(100, "USD");
var m6 = new MoneyRecord(100, "USD");
var m7 = m5 with { Amount = 200 };

Console.WriteLine(m5.Amount); // ?
Console.WriteLine(m7.Amount); // ?
Console.WriteLine(m5 == m6); // ?

Console.WriteLine("==========================");


var order1 = new Order(1, new MoneyRecord(100, "USD"));
var order2 = order1.UpdatePrice(150,"INR");

Console.WriteLine(order1.Price.Amount); // ?
Console.WriteLine(order2.Price.Amount); // ?
Console.WriteLine(order2.Price.Currency); // ?

Console.WriteLine("==========================");


