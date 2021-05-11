using System;
using System.Collections.Generic;

namespace MenuApp.OrderService.Logic.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid MenuItem { get; set; }
        public int Amount { get; set; }
        public List<IngredientChange> IngredientChanges { get; set; }
    }
}