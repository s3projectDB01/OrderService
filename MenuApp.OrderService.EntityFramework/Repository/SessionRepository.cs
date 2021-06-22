using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.OrderService.EntityFramework.Data;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

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
            await _db.SaveChangesAsync();
            return session;
        }

        public async Task<Session> Get(Guid id)
        {
            return await _db.Sessions.FindAsync(id);
        }

        public async Task<Session> Update(Session session)
        {
            _db.Sessions.Update(session);
            await _db.SaveChangesAsync();
            return session;
        }

        public async Task<IEnumerable<Session>> List()
        {
            return await _db.Sessions.ToListAsync();
        }

        public async Task<Session> GetSessionByOrderId(Guid orderId)
        {
            return await _db.Sessions.Include(x => x.Orders)
                .FirstAsync(x => x.Orders.Exists(x => x.Id.Equals(orderId)));
        }
    }
}