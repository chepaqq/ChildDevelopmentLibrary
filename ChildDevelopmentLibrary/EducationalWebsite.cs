using System;
using System.Collections.Generic;
using System.Text;
using ChildDevelopmentLibrary.Interfaces;
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
        public string Name { get; set; }

        public EducationalWebsite(IDBWebsite context)
        {
            _context = context;
        }

        public List<Child> GetChildrenByPeriod(Status period)
        {
            try
            {
                var filter = new ChildFilter();
                return filter.FilterByPeriod(_context.Children, period);
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
    }
}
