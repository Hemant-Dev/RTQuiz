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
    public class UserAnswerService : IUserAnswerService
    {
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IMapper _mapper;

        public UserAnswerService(IUserAnswerRepository userAnswerRepository, IMapper mapper)
        {
            _userAnswerRepository = userAnswerRepository;
            _mapper = mapper;
        }

        public async Task<GetUserAnswerDTO> CreateUserAnswer(CreateUserAnswerDTO userAnswerDTO)
        {
            var userAnswer = _mapper.Map<UserAnswer>(userAnswerDTO);
            var savedUserAnswer = await _userAnswerRepository.CreateAsync(userAnswer);
            var savedUserAnswerDTO = _mapper.Map<GetUserAnswerDTO>(savedUserAnswer);
            return savedUserAnswerDTO;
        }

        public async Task<GetUserAnswerDTO> DeleteUserAnswer(int id)
        {
            var userAnswerToDelete = await _userAnswerRepository.GetAsync(id);
            if (userAnswerToDelete == null)
                return null;
            var deletedUserAnswer = await _userAnswerRepository.DeleteAsync(userAnswerToDelete);
            var deletedUserAnswerDTO = _mapper.Map<GetUserAnswerDTO>(userAnswerToDelete);
            return deletedUserAnswerDTO;
        }

        public Task<IEnumerable<GetUserAnswerDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetUserAnswerDTO>> GetAllUserAnswer()
        {
            var userAnswerList = await _userAnswerRepository.GetAllAsync();
            var userAnswerDTOList = _mapper.Map<IEnumerable<GetUserAnswerDTO>>(userAnswerList);
            return userAnswerDTOList;
        }

        public async Task<IEnumerable<GetUserAnswerDTO>> GetAllUserAnswerWithOtherData()
        {
            var userAnswerList = await _userAnswerRepository.GetAllUserAnswerWithOtherData();
            var userAnswerDTOList = _mapper.Map<IEnumerable<GetUserAnswerDTO>>(userAnswerList);
            return userAnswerDTOList;
        }

        public async Task<GetUserAnswerDTO> GetUserAnswerById(int id)
        {
            var userAnswer = await _userAnswerRepository.GetAsync(id);
            if (userAnswer == null)
                return null;
            var userAnswerDTO = _mapper.Map<GetUserAnswerDTO>(userAnswer);
            return userAnswerDTO;
        }

        public async Task<GetUserAnswerDTO> UpdateUserAnswer(UpdateUserAnswerDTO userAnswerDTO)
        {
            var oldUserAnswer = await _userAnswerRepository.GetAsync(userAnswerDTO.Id);
            var newUserAnswer = _mapper.Map<UserAnswer>(userAnswerDTO);
            var newSavedUserAnswer = await _userAnswerRepository.UpdateAsync(newUserAnswer);
            var newSavedUserAnswerDTO = _mapper.Map<GetUserAnswerDTO>(newSavedUserAnswer);
            return newSavedUserAnswerDTO;
        }
    }
}
