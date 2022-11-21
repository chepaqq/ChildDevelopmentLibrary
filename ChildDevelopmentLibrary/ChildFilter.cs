using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public class ChildFilter
    {
        public List<Child> FilterByPeriod(IEnumerable<Child> children, Period period) =>
            children.Where(m => m.Period == period).ToList();

    }
}
