using AutoMapper;
using RTQuiz.DTO;
using RTQuiz.IRepositories;
using RTQuiz.IServices;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public async Task<GetRoomDTO> CreateRoom(CreateRoomDTO createRoomDTO)
        {
            var room = _mapper.Map<Room>(createRoomDTO);
            var savedRoomObj = await _roomRepository.CreateAsync(room);
            var roomDTO = _mapper.Map<GetRoomDTO>(savedRoomObj);
            return roomDTO;
        }

        public async Task<GetRoomDTO> DeleteRoom(int roomId)
        {
            var room = await _roomRepository.GetAsync(roomId);
            if (room == null)
                return null;

            var deletedRoom = await _roomRepository.DeleteAsync(room);
            var roomDTO = _mapper.Map<GetRoomDTO>(deletedRoom);
            return roomDTO;
        }

        public async Task<IEnumerable<GetRoomDTO>> GetAllRooms()
        {
            var roomList = await _roomRepository.GetAllAsync();
            var roomDTOList = _mapper.Map<IEnumerable<GetRoomDTO>>(roomList);
            return roomDTOList;
        }

        public async Task<IEnumerable<GetRoomDTO>> GetAllRoomsWithUsers()
        {
            var roomList = await _roomRepository.GetAllRoomsWithUsers();
            var roomDTOList = _mapper.Map<IEnumerable<GetRoomDTO>>(roomList);
            return roomDTOList;
        }

        public async Task<GetRoomDTO> GetRoomById(int id)
        {
            var room = await _roomRepository.GetAsync(id);
            var roomDTO = _mapper.Map<GetRoomDTO>(room);
            return roomDTO;
            
        }

        public async Task<GetRoomDTO> UpdateRoom(UpdateRoomDTO updateRoomDTO)
        {
            var oldRoom = await _roomRepository.GetAsync(updateRoomDTO.Id);
            if (oldRoom == null)
                return null;
            var newRoom = _mapper.Map<Room>(updateRoomDTO);
            var newRoomObj = await _roomRepository.UpdateAsync(newRoom);
            var newRoomDTO = _mapper.Map<GetRoomDTO>(newRoom);
            return newRoomDTO;
        }
    }
}
