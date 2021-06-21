using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Order> UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        { 
            return await _db.Orders.Include(o => o.Items).ThenInclude(o => o.IngredientChanges).OrderBy(o => o.Status).OrderBy(o => o.Status).ThenBy(o => o.Date).ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetPendingOrders()
        {
            return await _db.Orders.Include(o => o.Items).ThenInclude(o => o.IngredientChanges).Where(o => o.Status.Equals("pending")).OrderBy(o => o.Status).ThenBy(o => o.Date).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllNotDone()
        {
            return await _db.Orders.Include(o => o.Items).ThenInclude(o => o.IngredientChanges).Where(o => !o.Status.Equals("done")).OrderBy(o => o.Status).ThenBy(o => o.Date).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetInProgressOrders()
        {
            return await _db.Orders.Include(o => o.Items).ThenInclude(o => o.IngredientChanges).Where(o => o.Status == "inprogress").OrderBy(o => o.Status).ThenBy(o => o.Date).ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetDoneOrders()
        {
            return await _db.Orders.Include(o => o.Items).ThenInclude(o => o.IngredientChanges).Where(o => o.Status == "done").OrderBy(o => o.Status).ThenBy(o => o.Date).ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetCancelledOrders()
        {
            return await _db.Orders.Include(o => o.Items).ThenInclude(o => o.IngredientChanges).Where(o => o.Status == "cancelled").OrderBy(o => o.Status).ThenBy(o => o.Date).ToArrayAsync();
        }
    }
}
