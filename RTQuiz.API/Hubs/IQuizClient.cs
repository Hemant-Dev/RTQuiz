using RTQuiz.DTO;
using RTQuiz.Models;

namespace RTQuiz.API.Hubs
{
    public interface IQuizClient
    {
        Task ReceiveMessage(string message);
        Task CreateRoom(GetRoomDTO roomDTO);
        Task JoinRoom(int userId, string roomCode);
        Task LeaveRoom(int userId, string roomCode);

    }
}
