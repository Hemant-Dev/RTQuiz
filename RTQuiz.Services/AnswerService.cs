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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }
        public async Task<GetAnswerDTO> CreateAsnwer(CreateAnswerDTO createAnswerDTO)
        {
            var answerObj = _mapper.Map<Answer>(createAnswerDTO);
            var savedAnswerObj = await _answerRepository.CreateAsync(answerObj);
            var answerDTO = _mapper.Map<GetAnswerDTO>(savedAnswerObj);
            return answerDTO;
        }

        public async Task<GetAnswerDTO> DeleteAnswer(int id)
        {
            var answer = await _answerRepository.GetAsync(id);
            var deletedAnswer = await _answerRepository.DeleteAsync(answer);
            var answerDTO = _mapper.Map<GetAnswerDTO>(deletedAnswer);
            return answerDTO;
        }

        public async Task<IEnumerable<GetAnswerDTO>> GetAllAnswers()
        {
            var answerList = await _answerRepository.GetAllAsync();
            var answerDTOList = _mapper.Map<IEnumerable<GetAnswerDTO>>(answerList);
            return answerDTOList;
        }

        public async Task<GetAnswerDTO> GetAnswerById(int id)
        {
            var answer = await _answerRepository.GetAsync(id);
            var answerDTO = _mapper.Map<GetAnswerDTO>(answer);
            return answerDTO;
        }

        public async Task<GetAnswerDTO> UpdateAnswer(UpdateAnswerDTO updateAnswerDTO)
        {
            var oldAnswer = await _answerRepository.GetAsync(updateAnswerDTO.Id);
            if (oldAnswer == null)
                return null;
            var newAnswer = _mapper.Map<Answer>(updateAnswerDTO);
            var newAnswerObj = await _answerRepository.UpdateAsync(newAnswer);
            var newAnswerDTO = _mapper.Map<GetAnswerDTO>(newAnswerObj);
            return newAnswerDTO;
        }
    }
}
