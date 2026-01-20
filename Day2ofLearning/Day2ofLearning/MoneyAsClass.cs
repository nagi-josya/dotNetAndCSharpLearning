using System;
using System.Collections.Generic;
using System.Text;

namespace Day2ofLearning
{
    public class MoneyClass
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public MoneyClass(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }

}
