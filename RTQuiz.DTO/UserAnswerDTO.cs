using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateUserAnswerDTO(int QuizAttemptId, int QuestionId, int AnswerId, DateTime AnsweredAt);
    public record UpdateUserAnswerDTO(int Id, int QuizAttemptId, int QuestionId, int AnswerId, DateTime AnsweredAt);
    public record GetUserAnswerDTO(int Id, int QuizAttemptId, int QuestionId, int AnswerId, DateTime AnsweredAt);
}
