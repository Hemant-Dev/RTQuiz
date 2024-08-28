using Microsoft.EntityFrameworkCore;
using RTQuiz.Models;

namespace RTQuiz.Data
{
    public class QuizDBContext : DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuizSeries> QuizSeries { get; set; }
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);

            modelBuilder.Entity<Question>()
                .HasMany(a => a.Answers)
                .WithOne(q => q.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<User>()
                .HasMany(q => q.QuizAttempts)
                .WithOne(qa => qa.)

            base.OnModelCreating(modelBuilder);
        }

    }
}
