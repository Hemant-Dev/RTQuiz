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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService; 
        }
        // GET: api/<AnswerController>
        [HttpGet]
        public async Task<IEnumerable<GetAnswerDTO>> GetAll()
        {
            var res = await _answerService.GetAllAnswers();
            return res;
        }

        // GET api/<AnswerController>/5
        [HttpGet("{id}")]
        public async Task<GetAnswerDTO> Get(int id)
        {
            var res = await _answerService.GetAnswerById(id);
            return res;
        }

        // POST api/<AnswerController>
        [HttpPost]
        public async Task<GetAnswerDTO> Post([FromBody] CreateAnswerDTO createAnswerDTO)
        {
            var res = await _answerService.CreateAsnwer(createAnswerDTO);
            return res;
        }

        // PUT api/<AnswerController>/5
        [HttpPut("{id}")]
        public async Task<GetAnswerDTO> Put(int id, [FromBody] UpdateAnswerDTO updateAnswerDTO)
        {
            if (id != updateAnswerDTO.Id)
                return null;
            var res = await _answerService.UpdateAnswer(updateAnswerDTO);
            return res;
        }

        // DELETE api/<AnswerController>/5
        [HttpDelete("{id}")]
        public async Task<GetAnswerDTO> Delete(int id)
        {
            var res = await _answerService.DeleteAnswer(id);
            return res;
        }
    }
}
