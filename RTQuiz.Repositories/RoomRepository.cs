using Microsoft.EntityFrameworkCore;
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
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly QuizDBContext _quizDBContext;
        public RoomRepository(QuizDBContext quizDBContext) : base(quizDBContext)
        {
            _quizDBContext = quizDBContext;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsWithUsers()
        {
            var roomsList = await _quizDBContext.Rooms.Include(r => r.Participants).Select(r => new Room()
            {
                Id = r.Id,
                Name = r.Name,
                HostUserId = r.HostUserId,
                ActiveQuizId = r.ActiveQuizId,
                CreatedAt = r.CreatedAt,
                Participants = r.Participants.Select(p => new UserRoom()
                {
                    UserId = p.UserId,
                    RoomId = p.RoomId,
                    JoinedAt = p.JoinedAt,
                }).ToList(),
            }).ToListAsync();

            return roomsList;
        }
    }
}
