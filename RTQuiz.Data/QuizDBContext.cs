using Microsoft.EntityFrameworkCore;

namespace RTQuiz.Data
{
    public class QuizDBContext : DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options)
        {
            
        }

    }
}
