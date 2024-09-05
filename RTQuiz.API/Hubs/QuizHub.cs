using Microsoft.AspNetCore.SignalR;
using RTQuiz.Data;
using RTQuiz.DTO;
using RTQuiz.IServices;
using RTQuiz.Models;

namespace RTQuiz.API.Hubs
{
    public class QuizHub : Hub<IQuizClient>
    {
        private readonly QuizDBContext _quizDBContext;
        private readonly IRoomService _roomService;
        private readonly IDictionary<string, GetRoomDTO> _connection;

        public QuizHub(QuizDBContext quizDBContext, IRoomService roomService, IDictionary<string, GetRoomDTO> connection)
        {
            _quizDBContext = quizDBContext;
            _roomService = roomService;
            _connection = connection;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined.");
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }
        
        public async Task CreateRoom(CreateUserRoomDTO createUserRoomDTO)
        {
            var userRoom = await _roomService.GetRoomById(createUserRoomDTO.RoomId);

            await Groups.AddToGroupAsync(Context.ConnectionId, userRoom.Code);
            _connection[Context.ConnectionId] = userRoom;
            var room = new GetRoomDTO(userRoom.Id, userRoom.Code, userRoom.Name, userRoom.HostUserId, userRoom.ActiveQuizId, userRoom.CreatedAt, userRoom.Participants);

            await Clients.Group(userRoom.Code)
                .CreateRoom(room);
        }
    }
}
