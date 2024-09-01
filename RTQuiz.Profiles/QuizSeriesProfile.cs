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
    public class QuizSeriesProfile : Profile
    {
        public QuizSeriesProfile()
        {
            CreateMap<CreateQuizSeriesDTO, QuizSeries>();
            CreateMap<UpdateQuizSeriesDTO, QuizSeries>();
            CreateMap<QuizSeries, GetQuizSeriesDTO>();
        }
    }
}
