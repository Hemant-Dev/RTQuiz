using Helpers;
using Microsoft.EntityFrameworkCore;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Data
{
    public class DBSeed
    {
        private readonly ModelBuilder _modelBuilder;

        public DBSeed(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void SeedData()
        {
            var hashedPassword = PasswordHasherHelper.PasswordHasher("password");
            _modelBuilder.Entity<User>()
                .HasData( new User() { Id = 1, Username = "hemant", Email = "email", PasswordHash =  hashedPassword});

            _modelBuilder.Entity<QuizSeries>()
                .HasData( new QuizSeries() { Id = 1, Title = "Sample", Description = "Sample" });

            _modelBuilder.Entity<Category>()
                .HasData(new Category() { Id = 1, Name = "GK" });

            _modelBuilder.Entity<Quiz>()
                .HasData(new Quiz() { Id = 1, Title="Sample", Description = "Sample", Duration = TimeSpan.FromSeconds(1000), CategoryId = 1, Difficulty = Difficulty.Easy, QuizSeriesId = 1});

            _modelBuilder.Entity<Question>()
                .HasData(new Question() { Id = 1, QuizId = 1, Text = "Question 1", TimeLimit = TimeSpan.FromSeconds(500) });

            _modelBuilder.Entity<Answer>()
                .HasData(new Answer() {  Id = 1, QuestionId = 1, Text = "Answer 1", IsCorrect = true });
        }
    }
}
