using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;


namespace Accordia_Project.Hubs
{
    public class PresenceHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Others.SendAsync("UserIsOnline",Context.User.Identity.Name);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Others.SendAsync("UserIsOffline",Context.User.Identity.Name);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
