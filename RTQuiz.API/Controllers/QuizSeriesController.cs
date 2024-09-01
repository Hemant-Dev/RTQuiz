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
    public class QuizSeriesController : ControllerBase
    {
        private readonly IQuizSeriesService _quizSeriesService;

        public QuizSeriesController(IQuizSeriesService quizSeriesService)
        {
            _quizSeriesService = quizSeriesService;
        }
        // GET: api/<QuizSeriesController>
        [HttpGet]
        public Task<IEnumerable<GetQuizSeriesDTO>> GetAll()
        {
            var res = _quizSeriesService.GetAllQuizSeries();
            return res;
        }

        // GET api/<QuizSeriesController>/5
        [HttpGet("{id}")]
        public Task<GetQuizSeriesDTO> Get(int id)
        {
            var res = _quizSeriesService.GetQuizSeriesById(id);
            return res;
        }

        // POST api/<QuizSeriesController>
        [HttpPost]
        public Task<GetQuizSeriesDTO> Post([FromBody] CreateQuizSeriesDTO createQuizSeriesDTO)
        {
            var res = _quizSeriesService.CreateQuizSeries(createQuizSeriesDTO);
            return res;
        }

        // PUT api/<QuizSeriesController>/5
        [HttpPut("{id}")]
        public Task<GetQuizSeriesDTO> Put(int id, [FromBody] UpdateQuizSeriesDTO updateQuizSeriesDTO)
        {
            if (id != updateQuizSeriesDTO.Id)
                return null;
            var res = _quizSeriesService.UpdateQuizSeries(updateQuizSeriesDTO);
            return res;
        }

        // DELETE api/<QuizSeriesController>/5
        [HttpDelete("{id}")]
        public Task<GetQuizSeriesDTO> Delete(int id)
        {
            var res = _quizSeriesService.DeleteQuizSeries(id);
            return res;
        }
    }
}
