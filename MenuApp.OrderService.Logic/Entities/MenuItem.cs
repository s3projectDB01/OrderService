using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.OrderService.Logic.Entities
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public double Price { get; set; }   
    }
}
