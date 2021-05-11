using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.OrderService.EntityFramework.Data;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace MenuApp.OrderService.EntityFramework.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public void CreateNewOrder(Order order)
        {
            if (order != null) 
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("You fucked up");
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        { 
            return await _db.Orders.ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetPendingOrders()
        {
            return await _db.Orders.Where(o => o.Status.Equals("pending")).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetInProgressOrders()
        {
            return await _db.Orders.Where(o => o.Status == "inprogress").ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetDoneOrders()
        {
            return await _db.Orders.Where(o => o.Status == "done").ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetCancelledOrders()
        {
            return await _db.Orders.Where(o => o.Status == "cancelled").ToArrayAsync();
        }

    }
}
