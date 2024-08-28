using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Quiz> QuizAttempts { get; set; }
        public List<Room> HostedRooms { get; set; } 
        public List<UserRoom> JoinedRooms { get; set; }
    }
}
