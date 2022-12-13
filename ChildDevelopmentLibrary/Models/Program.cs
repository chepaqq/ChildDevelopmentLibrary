using System.Collections.Generic;

namespace ChildDevelopmentLibrary.Models
{
    public class Program
    {
        public string Name { get; set; }
        public List<Child> Children { get; set; } = new List<Child>();
    }
}
