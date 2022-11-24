using ChildDevelopmentLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public enum Status
    {
        Signed,
        IsStudying,
        CompletedStudies
    }
    public class EducationalWebsite : IEducationalWebsite
    {
        private readonly IDBWebsite _context;
        public string Name { get; set; }

        public EducationalWebsite(IDBWebsite context)
        {
            _context = context;
        }
        public void SubscribeToProgram(Child child, Program program)
        {
            if (child.Status == Status.Signed)
            {
                try
                {
                    _context.Programs
                        .Where(x => x.Name == program.Name)
                        .Single().Children
                        .Add(
                        _context.Children
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
                throw new Exception();
            }

        }

    }
}
