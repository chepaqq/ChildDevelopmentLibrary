using ChildDevelopmentLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary.DAL.Interfaces
{
    public interface IDBWebsite
    {
        public DbSet<EducationalProgram> Programs { get; set; }
        public DbSet<Child> Children { get; set; }
    }
}
