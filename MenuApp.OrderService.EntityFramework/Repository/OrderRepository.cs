using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.OrderService.EntityFramework.Data;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

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
                
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _db.Orders.ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetEverythingFromOrder()
        {
            return await _db.Orders.ToArrayAsync();
        }
    }
}
