using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.OrderService.Logic.Entities
{
    public class Order
    {
        public Guid Id { get; set;}

        public List<MenuItem> OrderList { get; set; }

        public double Prcie { get; set; }
    }
}
