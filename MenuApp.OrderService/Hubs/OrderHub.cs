using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;
using Microsoft.AspNetCore.SignalR;

namespace MenuApp.OrderService.Hubs
{
    public class OrderHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("NewOrder");
        }
    }
}