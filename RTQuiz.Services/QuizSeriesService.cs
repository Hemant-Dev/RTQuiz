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
    
    public class QuizSeriesService : IQuizSeriesService
    {
        private readonly IQuizSeriesRepository _quizSeriesRepository;
        private readonly IMapper _mapper;

        public QuizSeriesService(IQuizSeriesRepository quizSeriesRepository, IMapper mapper)
        {
            _quizSeriesRepository = quizSeriesRepository;
            _mapper = mapper;
        }
        public async Task<GetQuizSeriesDTO> CreateQuizSeries(CreateQuizSeriesDTO createQuizSeriesDTO)
        {
            var quizSeries = _mapper.Map<QuizSeries>(createQuizSeriesDTO);
            var quizSeriesObj = await _quizSeriesRepository.CreateAsync(quizSeries);
            var quizSeriesDTO = _mapper.Map<GetQuizSeriesDTO>(quizSeries);
            return quizSeriesDTO;
        }

        public async Task<GetQuizSeriesDTO> DeleteQuizSeries(int id)
        {
            var quizSeries = await _quizSeriesRepository.GetAsync(id);
            if (quizSeries == null)
                return null;
            var qSObj = await _quizSeriesRepository.DeleteAsync(quizSeries);
            var qSDTO = _mapper.Map<GetQuizSeriesDTO>(qSObj);
            return qSDTO;
        }

        public async Task<IEnumerable<GetQuizSeriesDTO>> GetAllQuizSeries()
        {
            var qSList = await _quizSeriesRepository.GetAllAsync();
            var qSDTOList = _mapper.Map<IEnumerable<GetQuizSeriesDTO>>(qSList); 
            return qSDTOList;
        }

        public async Task<GetQuizSeriesDTO> GetQuizSeriesById(int id)
        {
            var qS = await _quizSeriesRepository.GetAsync(id);
            var qSDTO = _mapper.Map<GetQuizSeriesDTO>(qS);
            return qSDTO;
        }

        public async Task<GetQuizSeriesDTO> UpdateQuizSeries(UpdateQuizSeriesDTO updateQuizSeriesDTO)
        {
            var oldQS = await _quizSeriesRepository.GetAsync(updateQuizSeriesDTO.Id);
            var newQSObj = _mapper.Map<QuizSeries>(updateQuizSeriesDTO);
            var newQS = await _quizSeriesRepository.UpdateAsync(newQSObj);
            var newQSDTO = _mapper.Map<GetQuizSeriesDTO>(newQS);
            return newQSDTO;
        }
    }
}
