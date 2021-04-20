using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;

namespace MenuApp.OrderService.Logic.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetEverythingFromOrder();
        void CreateNewOrder(Order order);
    }
}