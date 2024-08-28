﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Models
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int? QuizSeriesId { get; set; }
        public QuizSeries QuizSeries { get; set; }
        public int Score { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
