using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;

namespace MenuApp.OrderService.Logic.Interfaces.Repository
{
    public interface IForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> GetALl();
    }
}