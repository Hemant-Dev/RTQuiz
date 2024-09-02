using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface IUserAnswerService
    {
        Task<IEnumerable<GetUserAnswerDTO>> GetAllUserAnswer();
        Task<IEnumerable<GetUserAnswerDTO>> GetAllUserAnswerWithOtherData();
        Task<GetUserAnswerDTO> GetUserAnswerById(int id);
        Task<GetUserAnswerDTO> CreateUserAnswer(CreateUserAnswerDTO userAnswerDTO);
        Task<GetUserAnswerDTO> UpdateUserAnswer(UpdateUserAnswerDTO userAnswerDTO);
        Task<GetUserAnswerDTO> DeleteUserAnswer(int id);
    }
}
