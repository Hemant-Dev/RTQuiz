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
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        // GET: api/<QuizController>
        [HttpGet]
        public async Task<IEnumerable<GetQuizDTO>> GetAllQuizzes()
        {
            var quiz = await _quizService.GetAllQuizAsync();
            return quiz;
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public async Task<GetQuizDTO> GetQuiz(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            return quiz;
        }

        // POST api/<QuizController>
        [HttpPost]
        public Task<GetQuizDTO> Post([FromBody] CreateQuizDTO createQuizDTO)
        {
            var res = _quizService.CreateQuiz(createQuizDTO);
            return res;
        }

        // PUT api/<QuizController>/5
        [HttpPut("{id}")]
        public Task<GetQuizDTO> PutQuiz(int id, [FromBody] UpdateQuizDTO updateQuizDTO)
        {
            if (id != updateQuizDTO.Id)
                return null;
            var res = _quizService.UpdateQuiz(updateQuizDTO);
            return res;
        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public Task<GetQuizDTO> DeleteQuiz(int id)
        {
            var res = _quizService.DeleteQuiz(id);
            return res;
        }
    }
}
