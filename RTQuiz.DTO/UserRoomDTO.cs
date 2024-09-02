using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record CreateUserRoomDTO(int UserId, int RoomId, DateTime JoinedAt);
}
