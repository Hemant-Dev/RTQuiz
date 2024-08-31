using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;
using RTQuiz.IRepository;

namespace RTQuiz.Repositories
{
    public class BaseRepository<T> : IQuestionService<T> where T : class
    {
        private readonly QuizDBContext _quizDBContext;

        public BaseRepository(QuizDBContext quizDBContext)
        {
            _quizDBContext = quizDBContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _quizDBContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _quizDBContext.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var res = await _quizDBContext.Set<T>().ToListAsync();
            return res;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _quizDBContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var res = _quizDBContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
