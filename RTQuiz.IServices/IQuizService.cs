using RTQuiz.DTO;
using RTQuiz.Models;

namespace RTQuiz.IServices
{
    public interface IQuizService
    {
        Task<IEnumerable<GetQuizDTO>> GetAllQuizAsync();
        Task<GetQuizDTO> GetQuizByIdAsync(int id);
        Task<GetQuizDTO> CreateQuiz(CreateQuizDTO createQuizDTO);
        Task<GetQuizDTO> UpdateQuiz(UpdateQuizDTO updateQuizDTO);
        Task<GetQuizDTO> DeleteQuiz(int id);
    }
}
