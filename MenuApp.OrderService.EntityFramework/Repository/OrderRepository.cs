﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using MenuApp.OrderService.EntityFramework.Data;
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

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _db.Orders.ToArrayAsync();
        }
    }
}
