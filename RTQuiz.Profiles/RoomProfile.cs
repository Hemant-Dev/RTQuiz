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
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomDTO,Room>();      
            CreateMap<UpdateRoomDTO,Room>();      
            CreateMap<Room,GetRoomDTO>();      
        }
    }
}
