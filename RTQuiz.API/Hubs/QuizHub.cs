using Microsoft.AspNetCore.SignalR;

namespace RTQuiz.API.Hubs
{
    public class QuizHub : Hub
    {
        public async Task JoinRoom(string roomCode)
        {

        }

        public async Task LeaveRoom(string roomCode)
        {

        }

        public async Task SendAnswer(string roomCode, int questionId, int answerId)
        {

        }
        public async Task StartQuiz(string roomCode)
        {

        }
        public async Task NextQuestion(string roomCode, int questionId)
        {

        }

        public async Task EndQuiz(string roomCode)
        {

        }
    }
}
