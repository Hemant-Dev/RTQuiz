using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface IAnswerService
    {
        Task<IEnumerable<GetAnswerDTO>> GetAllAnswers();
        Task<GetAnswerDTO> GetAnswerById(int id);
        Task<GetAnswerDTO> CreateAsnwer(CreateAnswerDTO createAnswerDTO);
        Task<GetAnswerDTO> UpdateAnswer(UpdateAnswerDTO updateAnswerDTO);
        Task<GetAnswerDTO> DeleteAnswer(int id);
    }
}
