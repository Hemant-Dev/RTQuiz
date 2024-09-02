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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(QuizDBContext quizDBContext) : base(quizDBContext)
        {
            
        }
    }
}
