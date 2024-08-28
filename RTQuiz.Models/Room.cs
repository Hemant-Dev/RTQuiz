using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int HostUserId { get; set; }
        [Required]
        public int? ActiveQuizId { get; set; }
        public Quiz ActiveQuiz { get; set; }
        public IEnumerable<UserRoom> Participants { get; set; }

    }
}
