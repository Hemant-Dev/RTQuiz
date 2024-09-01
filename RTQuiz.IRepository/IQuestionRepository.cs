using RTQuiz.Data;
using RTQuiz.IRepository;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IRepositories
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        Task<IEnumerable<Question>> GetAllQuestion();
        Task<Question> GetQuestionById(int id);
    }
}
