using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public interface IEducationalWebsite
    {
        public List<Program> Programs { get; set; }
        public List<Child> Children { get; set; }
        public List<Child> GetChildrenByPeriod(Status period);
    }
}
