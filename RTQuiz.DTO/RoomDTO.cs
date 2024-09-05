using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateRoomDTO(string Code, string Name, int HostUserId, int ActiveQuizId, DateTime CreatedAt);
    public record UpdateRoomDTO(int Id, string Code, string Name, int HostUserId, int ActiveQuizId, DateTime CreateAt);
    public record GetRoomDTO(int Id, string Code, string Name, int HostUserId, int ActiveQuizId, DateTime CreatedAt, List<UserRoom>? Participants);

}
