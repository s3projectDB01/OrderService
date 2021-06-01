using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;

namespace MenuApp.OrderService.Logic.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

        Task<IEnumerable<Order>> GetPendingOrders();

        Task<IEnumerable<Order>> GetInProgressOrders();

        Task<IEnumerable<Order>> GetDoneOrders();

        Task<IEnumerable<Order>> GetCancelledOrders();
        
        Task<IEnumerable<Order>> GetAllNotDone();

        Task<IEnumerable<Order>> GetAllNotDone();

        void CreateNewOrder(Order order);

        Task<Order> UpdateOrder(Order order);
    }
}
