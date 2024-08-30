using RTQuiz.DTO;
using RTQuiz.IRepository;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IRepositories
{
    public interface IQuizRepository : IBaseRepository<Quiz>
    {
        Task<IEnumerable<Quiz>> GetAllQuizWithOtherData();
        Task<Quiz> GetQuizWithOtherDataById(int id);
    }
}
