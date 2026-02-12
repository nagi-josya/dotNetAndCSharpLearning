using ExceptionsHandsOn.Application.Interfaces;
using ExceptionsHandsOn.Domain.Entities;
using ExceptionsHandsOn.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHandsOn.Application.Services
{
    public class OrderService: IOrderService
    {
        public async Task<Order> GetOrderAsync(int id)
        {
            await Task.Delay(1000);
            if (id <= 0)
            {
                throw new BusinessRuleException("Invalid order id");
            }
            if(id==999)
            {
                throw new NotFoundException("order not found");
            }

            return new Order { Id = id , Total = 100};
        }

        public async Task ProcessOrderAsync(Order order)
        {
            await Task.Delay(1000);

            if(order.Total<=0)
            {
                throw new BusinessRuleException("order total must be positive");
            }
        }

        public async Task AggregateFailureDemo()
        {
            var task1 = Task.Run(() => throw new Exception("Task 1 Failed"));
            var task2 = Task.Run(() => throw new Exception("Task 2 Failed"));

            await Task.WhenAll(task1, task2);
        }
    }
}
