using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public class EducationalWebsite
    {
        public string Name { get; set; }

        public List<Program> Programs { get; set; } = new List<Program>();
        public List<Child> Children { get; set; } = new List<Child>();


        public void SubscribeToProgram(Child child, Program program)
        {
            if (child.IsStudied == false)
            {
                try
                {
                    Programs
                        .Where(x => x.Name == program.Name)
                        .Single().Children
                        .Add(
                        Children
                        .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                        .Single());

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                throw new Exception("Error in SubscribeToProgram");
            }

        }

    }
}
