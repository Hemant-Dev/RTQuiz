using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateUserDTO(string Username, string Email, string PasswordHash);
    public record UpdateUserDTO(int Id, string Username, string Email);
    public record GetUserDTO(int Id, string Email, List<Quiz>? QuizAttempts, List<Room>? HostedRooms, List<UserRoom>? JoinedRooms);

}
