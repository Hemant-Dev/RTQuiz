using Microsoft.AspNetCore.SignalR;

namespace RTQuiz.API.Hubs
{
    public class QuizHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined.");
        }
        public async Task SendMessage(string message)
        {
            await Clients.All
                .SendAsync("ReceiveMessage", message);
        }
    }
}
