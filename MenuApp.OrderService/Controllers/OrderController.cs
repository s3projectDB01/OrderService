using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.OrderService.Hubs;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace MenuApp.OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IHubContext<OrderHub> _orderHub;

        public OrderController(IOrderRepository orderRepository, ISessionRepository sessionRepository, IHubContext<OrderHub> orderHub) 
        {
            _orderRepository = orderRepository;
            _sessionRepository = sessionRepository;
            _orderHub = orderHub;
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
            else if (status == "allNotDone")
            {
                return await _orderRepository.GetAllNotDone();
            }
            else
            {
                return await _orderRepository.GetAll();
            }
        }

        [HttpPost]
        public async Task CreateOrder(Order order, Guid sessionId)
        {
            order.Date = DateTime.Now;

            if (sessionId.Equals(Guid.Empty))
            {
                _orderRepository.CreateNewOrder(order);
            }
            else
            {
                var session = await _sessionRepository.Get(sessionId);
                session.Orders.Add(order);
                await _sessionRepository.Update(session);
            }
            await _orderHub.Clients.All.SendAsync("NewOrder");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            await _orderRepository.UpdateOrder(order);
            return Ok(order);
        }

        [HttpGet("GetTableNumberByOrderId/{id:guid}")]
        public async Task<int> GetTableNumberByOrderId(Guid id)
        {
            var session = await _sessionRepository.GetSessionByOrderId(id);
            return session.TableNumber;
        }
    }
}
