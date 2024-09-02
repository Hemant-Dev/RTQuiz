using AutoMapper;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTQuiz.DTO;

namespace RTQuiz.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile() 
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Category, GetCategoryDTO>();
        }
    }
}
