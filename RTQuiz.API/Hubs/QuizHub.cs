﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public QuizHub(QuizDBContext quizDBContext, IRoomService roomService, IDictionary<string, UserRoom> connection, IMapper mapper)
        {
            _quizDBContext = quizDBContext;
            _roomService = roomService;
            _connection = connection;
            _mapper = mapper;
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

        public async Task LeaveRoom(string roomCode, int userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomCode);
            //_connection.Remove(Context.ConnectionId);
            await Clients.Group(roomCode).LeaveRoom(userId, roomCode);

        }

        public async Task StartQuiz(GetQuizDTO getQuizDTO, string roomCode)
        {
            await Clients.Group(roomCode).StartQuiz(getQuizDTO.Id, roomCode);

        }

        public async Task EndQuiz(GetQuizDTO getQuizDTO, string roomCode)
        {
            await Clients.Group(roomCode).EndQuiz(getQuizDTO.Id, roomCode);
        }

        public async Task NextQuestion(GetQuestionDTO getQuestionDTO, string roomCode)
        {
            var question = await _quizDBContext.Questions.FindAsync(getQuestionDTO.Id);
            var questionDTO = _mapper.Map<GetQuestionDTO>(question);
            await Clients.Group(roomCode).NextQuestion(roomCode, questionDTO);
        }
    }
}
