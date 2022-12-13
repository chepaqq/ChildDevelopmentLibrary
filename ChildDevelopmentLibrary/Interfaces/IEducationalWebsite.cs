using System;
using System.Collections.Generic;
using System.Text;
using ChildDevelopmentLibrary.Models;

namespace ChildDevelopmentLibrary.Interfaces
{
    public interface IEducationalWebsite
    {
        public List<Child> GetChildrenByStatus(Status period);
        public void SubscribeToProgram(Child child, Program program);
        public void StartStudying(Child child, Program program);
        public void CompleteStudying(Child child, Program program);

    }
}
