using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.OrderService.EntityFramework.Data;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.OrderService.EntityFramework.Repository
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly AppDbContext _db;
        
        public ForecastRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<WeatherForecast>> GetALl()
        {
            return await _db.Forecasts.ToArrayAsync();
        }
    }
}