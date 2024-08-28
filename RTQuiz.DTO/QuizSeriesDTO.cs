using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateQuizSeriesDTO(string Title, string Description, DateTime StartDate, DateTime EndDate);
    public record UpdateQuizSeriesDTO(int Id, string Title, string Description, DateTime StartDate, DateTime EndDate);
    public record GetQuizSeriesDTO(int Id, string Title, string Description, DateTime StartDate, DateTime EndDate, List<Quiz> Quizzes);
    
}
