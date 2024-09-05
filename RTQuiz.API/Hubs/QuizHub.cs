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
        private readonly IDictionary<string, UserRoom> _connection;

        public QuizHub(QuizDBContext quizDBContext, IRoomService roomService, IDictionary<string, UserRoom> connection)
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
            var userRoomSavedToDictionary = new UserRoom()
            {
                UserId = userRoom.HostUserId,
                RoomId = userRoom.Id
            };
            _connection[Context.ConnectionId] = userRoomSavedToDictionary;

            var room = new GetRoomDTO(userRoom.Id, userRoom.Code, userRoom.Name, userRoom.HostUserId, userRoom.ActiveQuizId, userRoom.CreatedAt, userRoom.Participants);

            await Clients.Group(userRoom.Code)
                .CreateRoom(room);
        }

        public async Task JoinRoom(GetRoomDTO roomDTO, int userId)
        {
            var userRoom = await _roomService.GetRoomById(roomDTO.Id);
            await Groups.AddToGroupAsync(Context.ConnectionId, userRoom.Code);
            var userRoomSavedToDictionary = new UserRoom()
            {
                UserId = userId,
                RoomId = userRoom.Id
            };
            _connection[Context.ConnectionId] = userRoomSavedToDictionary;

            await Clients.Group(userRoom.Code)
                .JoinRoom(userRoomSavedToDictionary);
        }

    }
}
