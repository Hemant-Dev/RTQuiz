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
        [ForeignKey(nameof(Quiz))]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        [Required]
        [StringLength(200)]
        public string Statement { get; set; }
        [Required]
        public IEnumerable<Answer> Answers { get; set; }
    }
}
