﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;

namespace ChildDevelopmentLibrary.BLL.Repository
{
    public class ChildFilter
    {
        public List<ChildDto> FilterByStatus(IEnumerable<ChildDto> children, Status period) =>
            children.Where(m => m.Status == period).ToList();
    }
}
