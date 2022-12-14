using Couchbase.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.Models;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.Interfaces;
using ChildDevelopmentLibrary.DAL.DBContext;

namespace ChildDevelopmentLibrary.BLL.Repository
{
    public enum Status
    {
        Signed,
        IsStudying,
        CompletedStudies
    }
    public class EducationalWebsiteRepository : IEducationalWebsiteRepository
    {
        private readonly DBWebsite _context;

        public EducationalWebsiteRepository(DBWebsite context)
        {
            _context = context;
        }
        public void SubscribeToProgram(ChildDto child, EducationalProgramDto program)
        {
            if (child != null && child.Status == Status.CompletedStudies)
            {
                try
                {
                    //_context.Children.Where(x => x.Id == child.Id);

                    //_context.Programs
                    //    .Where(x => x.Name == program.Name)
                    //    .Single().Children
                    //    .Add(
                    //    _context.Children
                    //    .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                    //    .Single());

                    //_context.Add(child);
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
        public void StartStudying(ChildDto child, EducationalProgramDto program)
        {
            if (child != null && child.Status == Status.Signed)
            {
                try
                {
                    //_context.Programs
                    //    .Where(x => x.Name == program.Name)
                    //    .Single().Children
                    //    .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                    //    .Single().Status = Status.IsStudying;

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

        public void CompleteStudying(ChildDto child, EducationalProgramDto program)
        {
            if (child != null && child.Status == Status.IsStudying)
            {
                try
                {
                    //_context.Programs
                    //    .Where(x => x.Name == program.Name)
                    //    .Single().Children
                    //    .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                    //    .Single().Status = Status.CompletedStudies;

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

        public List<ChildDto> GetChildrenByStatus(Status period)
        {
            try
            {
                //var filter = new ChildFilter();
                //return filter.FilterByStatus(_context.Children, period);
                return new List<ChildDto>();
            }
            catch (Exception e)
            {
                throw new InvalidArgumentException(e.Message);
            }
        }
    }
}
