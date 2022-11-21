using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public enum Period
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
    }
}
