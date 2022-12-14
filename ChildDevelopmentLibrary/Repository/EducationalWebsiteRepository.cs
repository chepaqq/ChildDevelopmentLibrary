using Couchbase.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.Models;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.Interfaces;
using ChildDevelopmentLibrary.DAL.DBContext;
using ChildDevelopmentLibrary.DAL.Entities;
using AutoMapper;

namespace ChildDevelopmentLibrary.BLL.Repository
{    
    public class EducationalWebsiteRepository : IEducationalWebsiteRepository
    {
        private readonly IDBWebsite _context;
        private readonly IMapper _mapper;

        public EducationalWebsiteRepository(IDBWebsite context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public EducationalWebsiteRepository(DBWebsite context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public void SubscribeToProgram(ChildDto child, EducationalProgramDto program)
        {
            if (child != null && child.Status == Status.CompletedStudies)
            {
                try
                {
                    var childEdit = _context.Children.Where(x => x.Id == child.Id).Single();
                    childEdit.Status = Status.Signed;

                    _context.Programs.Where(x => x.Id == program.Id).Single().Children.Add(childEdit);
                   
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
                    _context.Programs.Where(x => x.Id == program.Id).Single()
                        .Children.Where(x => x.Id == child.Id).Single().Status = Status.IsStudying;                   

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
                    var childEdit = _context.Children.Where(x => x.Id == child.Id).Single();
                    childEdit.Status = Status.CompletedStudies;

                    _context.Programs.Where(x => x.Id == program.Id).Single().Children.Remove(childEdit);

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
                var filter = new ChildFilter();
                return filter.FilterByStatus(_mapper.Map<IEnumerable<ChildDto>>(_context.Children.ToList()), period);
            }
            catch (Exception e)
            {
                throw new InvalidArgumentException(e.Message);
            }
        }
    }
}
