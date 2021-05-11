using System;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;

namespace MenuApp.OrderService.Logic.Interfaces.Repository
{
    public interface ISessionRepository
    {
        public Task<Session> Create(Session session);
        public Task<Session> Get(Guid id);
    }
}