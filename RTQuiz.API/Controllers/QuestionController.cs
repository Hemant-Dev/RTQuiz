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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        // GET: api/<QuestionController>
        [HttpGet]
        public async Task<IEnumerable<GetQuestionDTO>> GetAll()
        {
            var res = await _questionService.GetAllQuestions();
            return res;
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public Task<GetQuestionDTO> Get(int id)
        {
            var res = _questionService.GetQuestionById(id);
            return res;
        }

        // POST api/<QuestionController>
        [HttpPost]
        public Task<GetQuestionDTO> Post([FromBody] CreateQuestionDTO createQuestionDTO)
        {
            var res = _questionService.CreateQuestion(createQuestionDTO);
            return res;
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public Task<GetQuestionDTO> Put(int id, [FromBody] UpdateQuestionDTO updateQuestionDTO)
        {
            if (id != updateQuestionDTO.Id)
                return null;
            var res = _questionService.UpdateQuestion(updateQuestionDTO);
            return res;
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public Task<GetQuestionDTO> Delete(int id)
        {
            var res = _questionService.DeleteQuestion(id);
            return res;
        }
    }
}
