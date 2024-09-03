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
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuizSeries> QuizSeries { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; }

        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.HostedRooms)
                .WithOne(qa => qa.Host)
                .HasForeignKey(r => r.HostUserId);

            // Category relationships
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Quizzes)
                .WithOne(q => q.Category)
                .HasForeignKey(q => q.CategoryId);

            // QuizSeries relationships
            modelBuilder.Entity<QuizSeries>()
                .HasMany(qs => qs.Quizzes)
                .WithOne(q => q.QuizSeries)
                .HasForeignKey(q => q.QuizSeriesId);

            // Quiz relationships
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.QuizAttempts)
                .WithOne(qa => qa.Quiz)
                .HasForeignKey(qa => qa.QuizId);

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(qa => qa.Quiz)
                .HasForeignKey(qa => qa.QuizId);

            // Question relationships
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            // Room relationships
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Participants)
                .WithOne(ur => ur.Room)
                .HasForeignKey(ur => ur.RoomId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.ActiveQuiz)
                .WithMany(q => q.Rooms)
                .HasForeignKey(ur => ur.ActiveQuizId);

            // UserRoom relationships
            modelBuilder.Entity<UserRoom>()
                .HasKey(ur => new {ur.UserId, ur.RoomId});

            modelBuilder.Entity<UserRoom>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.JoinedRooms)
                .HasForeignKey(ur => ur.UserId);

            // QuizAttempt relationships
            modelBuilder.Entity<QuizAttempt>()
                .HasMany(qa => qa.UserAnswers)
                .WithOne(ua => ua.QuizAttempt)
                .HasForeignKey(ua => ua.QuizAttemptId);

            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Room)
                .WithMany()
                .HasForeignKey(qa => qa.RoomId);

            // UserAnswer relationships
            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.Question)
                .WithMany()
                .HasForeignKey(ua => ua.QuestionId);

            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.Answer)
                .WithMany()
                .HasForeignKey(ua => ua.AnswerId);

            // LeaderboardEntry relationships
            modelBuilder.Entity<LeaderboardEntry>()
                .HasOne(le => le.User)
                .WithMany()
                .HasForeignKey(le => le.UserId);

            modelBuilder.Entity<LeaderboardEntry>()
                .HasOne(le => le.Quiz)
                .WithMany()
                .HasForeignKey(le => le.QuizId);

            modelBuilder.Entity<LeaderboardEntry>()
                .HasOne(le => le.QuizSeries)
                .WithMany()
                .HasForeignKey(le => le.QuizSeriesId);

            base.OnModelCreating(modelBuilder);
            new DBSeed(modelBuilder).SeedData();
        }
        
    }
}
