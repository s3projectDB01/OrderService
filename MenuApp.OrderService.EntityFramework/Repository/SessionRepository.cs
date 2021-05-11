using System;
using System.Threading.Tasks;
using MenuApp.OrderService.EntityFramework.Data;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;

namespace MenuApp.OrderService.EntityFramework.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _db;

        public SessionRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<Session> Create(Session session)
        {
            await _db.Sessions.AddAsync(session);
            return session;
        }

        public async Task<Session> Get(Guid id)
        {
            return await _db.Sessions.FindAsync(id);
        }
    }
}