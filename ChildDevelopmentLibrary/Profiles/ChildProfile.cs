using AutoMapper;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace ChildDevelopmentLibrary.BLL.Profiles
{
    public class ChildProfile: Profile
    {
        public ChildProfile()
        {
            CreateMap<Child, ChildDto>();
            CreateMap<ChildDto, Child>();
        }
    }
}
