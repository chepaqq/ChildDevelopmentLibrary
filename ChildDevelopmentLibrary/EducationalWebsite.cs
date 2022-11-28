using System;
using System.Collections.Generic;
using System.Text;
using ChildDevelopmentLibrary.Interfaces;
using ChildDevelopmentLibrary.Models;
using Couchbase.Core.Exceptions;

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
        private readonly DBWebsite _context;

        public EducationalWebsite(IDBWebsite context)
        {
            _context = context;
        }

        public List<Child> GetChildrenByStatus(Status period)
        {
            try
            {
                var filter = new ChildFilter();
                return filter.FilterByStatus(_context.Children, period);
            }
            catch(Exception)
            {
                throw new InvalidArgumentException();
            }
        }
    }
}
