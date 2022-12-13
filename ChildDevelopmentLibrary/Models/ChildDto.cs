using Castle.Components.DictionaryAdapter;
using System;

namespace ChildDevelopmentLibrary.Models
{
    public class ChildDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Status Status { get; set; } = Status.CompletedStudies;
    }
}
