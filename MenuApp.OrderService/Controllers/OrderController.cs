﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IEnumerable<Order>> Get() 
        {
            return await _orderRepository.GetAll();
        }

        [HttpPost]
        public void CreateOrder(Order order) 
        {
            _orderRepository.CreateNewOrder(order);
        }
    }
}