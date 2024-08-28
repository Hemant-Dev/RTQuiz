using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateAnswerDTO(int QuestionId, string Text, bool IsCorrect);
    public record UpdateAnswerDTO(int Id, int QuestionId, string Text, bool IsCorrect);
    public record GetAnswerDTO(int Id, int QuestionId, string Text, bool IsCorrect);

}
