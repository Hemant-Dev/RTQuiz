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
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionDTO, Question>();
            CreateMap<UpdateQuestionDTO, Question>();
            CreateMap<Question, GetQuestionDTO>();
        }
    }
}
