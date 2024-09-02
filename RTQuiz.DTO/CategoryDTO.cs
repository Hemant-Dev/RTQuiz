using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{

    public record CreateCategoryDTO(string Name);
    public record UpdateCategoryDTO(int Id, string Name);
    public record GetCategoryDTO(int Id, string Name, List<Quiz> Quizzes);

}
