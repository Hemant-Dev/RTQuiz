using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        [Required]
        [StringLength(200)]
        public string Text { get; set; }
        public TimeSpan TimeLimit { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
