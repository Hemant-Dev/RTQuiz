using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RTQuiz.DTO;
using RTQuiz.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RTQuiz.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<IEnumerable<GetRoomDTO>> GetAll()
        {
            var res = await _roomService.GetAllRoomsWithUsers();
            return res;
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<GetRoomDTO> Get(int id)
        {
            var res = await _roomService.GetRoomById(id);
            return res;
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<GetRoomDTO> Post([FromBody] CreateRoomDTO createRoomDTO)
        {
            var res = await _roomService.CreateRoom(createRoomDTO);
            return res;
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public async Task<GetRoomDTO> Put(int id, [FromBody] UpdateRoomDTO updateRoomDTO)
        {
            var res = await _roomService.UpdateRoom(updateRoomDTO);
            return res;
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public Task<GetRoomDTO> Delete(int id)
        {
            var res = _roomService.DeleteRoom(id);
            return res;
        }
    }
}
