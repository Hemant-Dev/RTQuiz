using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;
using RTQuiz.IRepositories;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Repositories
{
    public class UserAnswerRepository : BaseRepository<UserAnswer>, IUserAnswerRepository
    {
        private readonly QuizDBContext _quizDBContext;
        public UserAnswerRepository(QuizDBContext quizDBContext) : base(quizDBContext)
        {
            _quizDBContext = quizDBContext;   
        }

        public async Task<IEnumerable<UserAnswer>> GetAllUserAnswerWithOtherData()
        {
            var userAnswerList = await _quizDBContext.UserAnswers
                .Include(u => u.QuizAttempt)
                .Include(u => u.Answer)
                .Include(u => u.Question)
                .ToListAsync();
            return userAnswerList;
        }
    }
}
