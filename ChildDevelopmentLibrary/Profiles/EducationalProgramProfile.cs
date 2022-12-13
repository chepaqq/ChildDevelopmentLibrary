using AutoMapper;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary.BLL.Profiles
{
    public class EducationalProgramProfile : Profile
    {
        public EducationalProgramProfile()
        {
            CreateMap<EducationalProgram, EducationalProgramDto>();
            CreateMap<EducationalProgramDto, EducationalProgram>();
        }
    }
}
