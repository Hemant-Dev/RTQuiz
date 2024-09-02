using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RTQuiz.DTO;
using RTQuiz.IServices;
using RTQuiz.Services;

namespace RTQuiz.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerService _userAnswerService;

        public UserAnswerController(IUserAnswerService userAnswerService)
        {
            _userAnswerService = userAnswerService;
        }

        // GET: api/<UserRoomController>
        [HttpGet]
        public async Task<IEnumerable<GetUserAnswerDTO>> GetAll()
        {
            var res = await _userAnswerService.GetAllUserAnswer();
            return res;
        }

        // GET api/<UserRoomController>/5
        [HttpGet("{id}")]
        public async Task<GetUserAnswerDTO> Get(int id)
        {
            var res = await _userAnswerService.GetUserAnswerById(id);
            return res;
        }

        // POST api/<UserRoomController>
        [HttpPost]
        public async Task<GetUserAnswerDTO> Post([FromBody] CreateUserAnswerDTO createUserAnswerDTO)
        {
            var res = await _userAnswerService.CreateUserAnswer(createUserAnswerDTO);
            return res;
        }

        // PUT api/<UserRoomController>/5
        [HttpPut("{id}")]
        public async Task<GetUserAnswerDTO> Put(int id, [FromBody] UpdateUserAnswerDTO updateUserAnswerDTO)
        {
            var res = await _userAnswerService.UpdateUserAnswer(updateUserAnswerDTO);
            return res;
        }

        // DELETE api/<UserRoomController>/5
        [HttpDelete("{id}")]
        public async Task<GetUserAnswerDTO> Delete(int id)
        {
            var res = await _userAnswerService.DeleteUserAnswer(id);
            return res;
        }
    }
}
