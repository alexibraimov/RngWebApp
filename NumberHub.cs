using Microsoft.AspNetCore.SignalR;

namespace RngApp;
public class NumberHub : Hub
{
    public async Task SendNumber(int number)
    {
        await Clients.All.SendAsync("ReceiveNumber", number);
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await SendNumber(Random.Shared.Next(0, 1000));
    }
}
