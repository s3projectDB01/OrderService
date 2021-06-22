using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;

namespace MenuApp.OrderService.Logic.Interfaces.Repository
{
    public interface ISessionRepository
    {
        public Task<Session> Create(Session session);
        public Task<Session> Get(Guid id);
        public Task<Session> Update(Session session);
        public Task<IEnumerable<Session>> List();
        public Task<Session> GetSessionByOrderId(Guid orderId);
    }
}