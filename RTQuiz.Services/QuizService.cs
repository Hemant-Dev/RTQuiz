using AutoMapper;
using RTQuiz.DTO;
using RTQuiz.IRepositories;
using RTQuiz.IServices;
using RTQuiz.Models;

namespace RTQuiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }
        public async Task<GetQuizDTO> CreateQuiz(CreateQuizDTO createQuizDTO)
        {
            var quizObj = _mapper.Map<Quiz>(createQuizDTO);
            await _quizRepository.CreateAsync(quizObj);
            var quiz = _mapper.Map<GetQuizDTO>(quizObj);
            return quiz;
        }

        public async Task<GetQuizDTO> DeleteQuiz(int id)
        {
            var quizDTO = await _quizRepository.GetAsync(id);
            if (quizDTO == null)
                return null;
            await _quizRepository.DeleteAsync(quizDTO);
            var returnDTO = _mapper.Map<GetQuizDTO>(quizDTO);
            return returnDTO;
        }

        public async Task<IEnumerable<GetQuizDTO>> GetAllQuizAsync()
        {
            var quizzesDTO = await _quizRepository.GetAllAsync();
            if (quizzesDTO == null)
                return null;
            var quizzesDTOList = _mapper.Map<IEnumerable<GetQuizDTO>>(quizzesDTO);
            return quizzesDTOList;
        }

        public async Task<GetQuizDTO> GetQuizByIdAsync(int id)
        {
            var quiz = await _quizRepository.GetAsync(id);
            var quizDTO = _mapper.Map<GetQuizDTO>(quiz);
            return quizDTO;
        }

        public async Task<GetQuizDTO> UpdateQuiz(UpdateQuizDTO updateQuizDTO)
        {
            var oldQuiz = await _quizRepository.GetAsync(updateQuizDTO.Id);
            if(oldQuiz == null)
                return null;
            await _quizRepository.UpdateAsync(oldQuiz);
            var quizDTO = _mapper.Map<GetQuizDTO>(oldQuiz);
            return quizDTO;
        }
    }
}
