using System.Collections.Generic;

namespace ChildDevelopmentLibrary.Models
{
    public class EducationalProgramDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChildDto> Children { get; set; }
    }
}
