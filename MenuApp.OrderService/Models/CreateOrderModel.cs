using System;
using MenuApp.OrderService.Logic.Entities;

namespace MenuApp.OrderService.Models
{
    public class CreateOrderModel
    {
        public Order Order { get; set; }
        public Guid SessionId { get; set; }
    }
}