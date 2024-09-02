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

        public Task<IEnumerable<UserAnswer>> GetAllUserAnswerWithOtherData()
        {
            var answerList = _quizDBContext.UserAnswers.Include()
        }
    }
}
