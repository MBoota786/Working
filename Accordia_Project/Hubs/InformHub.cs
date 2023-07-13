using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Accordia_Project.Hubs
{
    public interface IHubClient
    {
        Task InformClient(string message);
    }

    public class InformHub : Hub<IHubClient>
    {
        
    }
}
