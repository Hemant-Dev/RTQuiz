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
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly QuizDBContext _quizDBContext;
        public QuestionRepository(QuizDBContext quizDBContext) : base(quizDBContext)
        {
            _quizDBContext = quizDBContext;
        }

        public async Task<IEnumerable<Question>> GetAllQuestion()
        {
            var questionList = await _quizDBContext.Questions.Include(q => q.Answers)
                .Select(q => new Question()
                {
                    Id = q.Id,
                    QuizId = q.QuizId,
                    Text = q.Text,
                    TimeLimit = q.TimeLimit,
                    Answers = q.Answers.Select(a => new Answer()
                    {
                        Id = a.Id,
                        QuestionId = a.Id,
                        Text = a.Text,
                        IsCorrect = a.IsCorrect
                    }).ToList(),
                }).ToListAsync();

            return questionList;
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var quiz = await _quizDBContext.Questions.Include(q => q.Answers).Select(q => new Question()
            {
                Id = q.Id,
                QuizId = q.QuizId,
                Text = q.Text,
                TimeLimit = q.TimeLimit,
                Answers = q.Answers.Select(a => new Answer()
                {
                    Id = a.Id,
                    QuestionId = a.Id,
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).FirstOrDefaultAsync(q => q.Id == id);

            return quiz;
        }
    }
}
