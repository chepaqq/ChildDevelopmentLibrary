using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.Models;

namespace ChildDevelopmentLibrary
{
    public class ChildFilter
    {
        public List<ChildDto> FilterByStatus(IEnumerable<ChildDto> children, Status period) =>
            children.Where(m => m.Status == period).ToList();
    }
}
