using AutoMapper;
using RTQuiz.DTO;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<CreateQuizDTO, Quiz>();
            CreateMap<UpdateQuizDTO, Quiz>();
            CreateMap<Quiz, GetQuizDTO>();
        }
    }
}
