using System;
using System.Collections.Generic;

namespace MenuApp.OrderService.Logic.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}