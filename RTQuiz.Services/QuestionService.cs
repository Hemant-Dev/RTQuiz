using AutoMapper;
using RTQuiz.DTO;
using RTQuiz.IRepositories;
using RTQuiz.IRepository;
using RTQuiz.IServices;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Services
{
    public class QuestionService :  IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetQuestionDTO> CreateQuestion(CreateQuestionDTO createQuestionDTO)
        {
            var question = _mapper.Map<Question>(createQuestionDTO);
            var savedQuestionDTO = await _questionRepository.CreateAsync(question);
            var questionDTO = _mapper.Map<GetQuestionDTO>(savedQuestionDTO);
            return questionDTO;
        }

        public async Task<GetQuestionDTO> DeleteQuestion(int id)
        {
            var question = await _questionRepository.GetQuestionById(id);
            if (question == null)
                return null;
            
            var deletedRoom = await _questionRepository.DeleteAsync(question);
            var questionDTO = _mapper.Map<GetQuestionDTO>(deletedRoom);
            return questionDTO;
        }

        public async Task<IEnumerable<GetQuestionDTO>> GetAllQuestions()
        {
            var questionList = await _questionRepository.GetAllQuestion();
            var questionDTOList = _mapper.Map<IEnumerable<GetQuestionDTO>>(questionList);
            return questionDTOList;
        }

        public async Task<GetQuestionDTO> GetQuestionById(int id)
        {
            var question = await _questionRepository.GetQuestionById(id);
            var questionDTO = _mapper.Map<GetQuestionDTO>(question);
            return questionDTO;
        }

        public async Task<GetQuestionDTO> UpdateQuestion(UpdateQuestionDTO questionDTO)
        {
            var oldQuestion = _questionRepository.GetAsync(questionDTO.Id);
            if (oldQuestion == null)
                return null;
            var updatedQuestion = _mapper.Map<Question>(questionDTO);
            var newQuestion = await _questionRepository.UpdateAsync(updatedQuestion);
            var returnDTO = _mapper.Map<GetQuestionDTO>(newQuestion);

            return returnDTO;
        }
    }
}
