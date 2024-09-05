using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Models
{
    [Index(nameof(UserId),nameof(RoomId))]
    public class UserRoom
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required]
        public DateTime JoinedAt { get; set; } = DateTime.Now;
    }
}
