﻿using System;
using System.Collections.Generic;

namespace MenuApp.OrderService.Logic.Entities
{
    public class Order
    {
        public Guid Id { get; set;} 

        public List<MenuItem> OrderList { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public int TableNumber { get; set; }
    }
}