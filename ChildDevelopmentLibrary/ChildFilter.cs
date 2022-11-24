using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.Models;

namespace ChildDevelopmentLibrary
{
    public class ChildFilter
    {
        public List<Child> FilterByPeriod(IEnumerable<Child> children, Status period) =>
            children.Where(m => m.Status == period).ToList();

    }
}
