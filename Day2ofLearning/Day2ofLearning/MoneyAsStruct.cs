using System;
using System.Collections.Generic;
using System.Text;

namespace Day2ofLearning
{
    public struct MoneyStruct
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public MoneyStruct(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }

}
