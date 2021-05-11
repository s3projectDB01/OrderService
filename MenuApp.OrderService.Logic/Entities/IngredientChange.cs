using System;

namespace MenuApp.OrderService.Logic.Entities
{
    public class IngredientChange
    {
        public Guid Id { get; set; }
        public Guid IngredientId { get; set; }
        public int Amount { get; set; }
    }
}