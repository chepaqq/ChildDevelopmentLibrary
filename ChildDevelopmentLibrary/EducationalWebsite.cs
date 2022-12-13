using ChildDevelopmentLibrary.Interfaces;
using Couchbase.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.Models;

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

        public EducationalWebsite(IDBWebsite context)
        {
            _context = context;
        }
        public void SubscribeToProgram(Child child, Program program)
        {
            if (child != null && child.Status == Status.Signed)
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
                    throw new InvalidArgumentException(e.Message);
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }

        }
        public void StartStudying(Child child, Program program)
        {
            if (child != null && child.Status == Status.Signed)
            {
                try
                {
                    _context.Programs
                        .Where(x => x.Name == program.Name)
                        .Single().Children
                        .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                        .Single().Status = Status.IsStudying;

                }
                catch (Exception e)
                {
                    throw new InvalidArgumentException(e.Message);
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }
        }

        public void CompleteStudying(Child child, Program program)
        {
            if (child != null && child.Status == Status.IsStudying)
            {
                try
                {
                    _context.Programs
                        .Where(x => x.Name == program.Name)
                        .Single().Children
                        .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                        .Single().Status = Status.CompletedStudies;

                }
                catch (Exception e)
                {
                    throw new InvalidArgumentException(e.Message);
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }
        }

        public List<Child> GetChildrenByStatus(Status period)
        {
            try
            {
                var filter = new ChildFilter();
                return filter.FilterByStatus(_context.Children, period);
            }
            catch (Exception)
            {
                throw new InvalidArgumentException();
            }
        }
    }
}
