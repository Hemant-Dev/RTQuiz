using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTQuiz.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public Difficulty Difficulty { get; set; }
        public int? QuizSeriesId { get; set; }
        public QuizSeries QuizSeries { get; set; }
        public List<Question> Questions { get; set; }
        public List<QuizAttempt> QuizAttempts { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
