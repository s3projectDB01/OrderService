﻿using System;
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
    }
}