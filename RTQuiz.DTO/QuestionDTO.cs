using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateQuestionDTO(int QuizId, string Text, TimeSpan TimeLimit);
    public record UpdateQuestionDTO(int Id, int QuizId, string Text, TimeSpan TimeLimit);
    public record GetQuestionDTO(int Id, int QuizId, string Text, TimeSpan TimeLimit, List<Answer> Answers);

}
