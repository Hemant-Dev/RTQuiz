using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateQuizDTO(string Title, string Description, TimeSpan Duration, int CategoryId, Difficulty Difficulty, int? QuizSeriesId);

    public record UpdateQuizDTO(int Id, string Title, string Description, TimeSpan Duration, int CategoryId, Difficulty Difficulty, int? QuizSeriesId);
    public record GetQuizDTO(int Id, string Title, string Description, TimeSpan Duration, int CategoryId, Difficulty Difficulty, int? QuizSeriesId, List<Question> Questions, List<QuizAttempt> QuizAttempts, List<Room> Rooms);
}
