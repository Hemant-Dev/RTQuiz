using AutoMapper;
using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Profiles
{
    public class QuizSeriesProfile : Profile
    {
        public QuizSeriesProfile()
        {
            CreateMap<CreateQuizSeriesDTO, QuizSeriesProfile>();
            CreateMap<UpdateQuizSeriesDTO, QuizSeriesProfile>();
            CreateMap<QuizSeriesProfile, GetQuizSeriesDTO>();
        }
    }
}
