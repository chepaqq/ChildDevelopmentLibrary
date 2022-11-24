using System;
using System.Collections.Generic;
using System.Text;
using ChildDevelopmentLibrary.Models;

namespace ChildDevelopmentLibrary.Interfaces
{
    public interface IEducationalWebsite
    {
        public List<Child> GetChildrenByPeriod(Status period);
    }
}
