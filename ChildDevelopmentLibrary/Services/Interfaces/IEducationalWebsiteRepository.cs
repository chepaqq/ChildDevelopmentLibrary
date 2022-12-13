using System;
using System.Collections.Generic;
using System.Text;
using ChildDevelopmentLibrary.Models;

namespace ChildDevelopmentLibrary.BLL.Services.Interfaces
{
    public interface IEducationalWebsiteRepository
    {
        public List<ChildDto> GetChildrenByStatus(Status period);
        public void SubscribeToProgram(ChildDto child, EducationalProgramDto program);
        public void StartStudying(ChildDto child, EducationalProgramDto program);
        public void CompleteStudying(ChildDto child, EducationalProgramDto program);

    }
}
