using RTQuiz.DTO;
using RTQuiz.Models;

namespace RTQuiz.API.Hubs
{
    public interface IQuizClient
    {
        Task ReceiveMessage(string message);
        Task CreateRoom(GetRoomDTO roomDTO);
        Task JoinRoom(UserRoom room);
        Task LeaveRoom(int userId, string roomCode);
        Task StartQuiz(int quizId, string roomCode);
        Task EndQuiz(int quizId, string roomCode);
        Task NextQuestion(string roomCode, GetQuestionDTO questionDTO);
        Task AnswerReceived(string roomCode, int questionId, int answerId);
        Task ReceiveConnectedUsers(IEnumerable<string> users, string roomCode);
    }
}
