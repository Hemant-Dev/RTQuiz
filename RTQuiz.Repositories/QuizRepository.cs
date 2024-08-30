using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;
using RTQuiz.DTO;
using RTQuiz.IRepositories;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Repositories
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        private readonly QuizDBContext _quizDBContext;
        public QuizRepository(QuizDBContext quizDBContext) : base(quizDBContext)
        {
            _quizDBContext = quizDBContext;
        }
        public async Task<IEnumerable<Quiz>> GetAllQuizWithOtherData()
        {
            var quizList = await _quizDBContext.Quizzes.Include(q => q.Questions).ToListAsync();
            var flattenedQuizList = quizList.Select(q => new Quiz()
            {
                Id = q.Id,
                Title = q.Title,
                Questions = q.Questions.Select(qs => new Question()
                {
                    Id = qs.Id,
                    Text = qs.Text
                }).ToList()
            }).ToList();

            return flattenedQuizList;
        }

        public async Task<Quiz> GetQuizWithOtherDataById(int id)
        {
            var quizObj = await _quizDBContext.Quizzes.Include(q => q.Questions)
                .Select(q => new Quiz()
                {
                    Id = q.Id,
                    Title = q.Title,
                    Difficulty = q.Difficulty,
                    Questions = q.Questions.Select(qs => new Question()
                    {
                        Id = qs.Id,
                        QuizId = qs.QuizId,

                    }).ToList()
                })
                .FirstOrDefaultAsync(q => q.Id == id);

            return quizObj;
        }
    }
}
