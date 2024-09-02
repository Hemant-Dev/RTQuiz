using RTQuiz.DTO;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface IRoomService
    {
        Task<IEnumerable<GetRoomDTO>> GetAllRooms();
        Task<IEnumerable<GetRoomDTO>> GetAllRoomsWithUsers();
        Task<GetRoomDTO> GetRoomById(int id);
        Task<GetRoomDTO> CreateRoom(CreateRoomDTO createRoomDTO);
        Task<GetRoomDTO> UpdateRoom(UpdateRoomDTO updateRoomDTO);
        Task<GetRoomDTO> DeleteRoom(int roomId);
    }
}
