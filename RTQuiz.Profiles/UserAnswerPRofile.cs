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
    public class UserAnswerProfile : Profile
    {
        public UserAnswerProfile()
        {
            CreateMap<CreateUserAnswerDTO, UserAnswer>();
            CreateMap<UpdateUserAnswerDTO, UserAnswer>();
            CreateMap<Answer, GetUserAnswerDTO>();
        }
    }
}
