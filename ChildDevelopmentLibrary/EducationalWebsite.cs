using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public enum Status
    {
        Signed,
        IsStudying,
        CompletedStudies
    }
    public class EducationalWebsite
    {
        public string Name { get; set; }

        public List<Program> Programs { get; set; } = new List<Program>();
        public List<Child> Children { get; set; } = new List<Child>();

        public List<Child> GetChildrenByPeriod(List<Child> children, Status period)
        {
            try
            {
                var filter = new ChildFilter();
                return filter.FilterByPeriod(children, period);
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
    }
}
