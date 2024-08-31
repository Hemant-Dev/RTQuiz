using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface IQuestionService
    {
        Task<IEnumerable<GetQuestionDTO>> GetAllQuestions();
        Task<GetQuestionDTO> GetQuestionById(int id);
        Task<GetQuestionDTO> CreateQuestion(CreateQuestionDTO questionDTO);
        Task<GetQuestionDTO> UpdateQuestion(UpdateQuestionDTO questionDTO);
        Task<GetQuestionDTO> DeleteQuestion(int id);
    }
}
