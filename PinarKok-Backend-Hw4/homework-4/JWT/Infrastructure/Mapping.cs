using JWT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Models;
using OnlineExaminationSystem.Entities.Dtos;

namespace JWT.Infrastructure
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Exam, ExamDto>()
                .ForMember(dest => dest.Title, opt =>
                    opt.MapFrom(src => src.Title));
            CreateMap<User, UserInfo>()
                .ForMember(desc => desc.FullName, opt =>
                    opt.MapFrom(src => string.Concat(src.Name, src.LastName));
        }
    }
}
