using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MenuApp.OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{status}")] // status => pending, inprogress, done, cancelled
        //[HttpGet("{status}/{lastName}/{address}")]
        public async Task<IEnumerable<Order>> GetOrders(string status)
        {
            if (status == "pending")
            {
                return await _orderRepository.GetPendingOrders();
            }
            else if (status == "inprogress")
            {
                return await _orderRepository.GetInProgressOrders();
            }
            else if (status == "done")
            {
                return await _orderRepository.GetDoneOrders();
            }
            else if (status == "cancelled")
            {
                return await _orderRepository.GetCancelledOrders();
            }
            else if (status == "all")
            {
                return await _orderRepository.GetAll();
            }
            else
            {
                return await _orderRepository.GetAll();
            }
        }

        [HttpPost]
        public void CreateOrder(Order order) 
        {
            _orderRepository.CreateNewOrder(order);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            await _orderRepository.UpdateOrder(order);
            return Ok(order);
        }
    }
}
