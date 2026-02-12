using ExceptionsHandsOn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHandsOn.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int id);
        Task ProcessOrderAsync(Order order);
        Task AggregateFailureDemo();
    }
}
