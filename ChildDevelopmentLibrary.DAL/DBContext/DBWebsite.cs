using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ChildDevelopmentLibrary.DAL.DBContext
{
    public class DBWebsite : DbContext, IDBWebsite
    {
        public DbSet<EducationalProgram> Programs { get; set; }
        public DbSet<Child> Children { get; set; }

        public DBWebsite()
        {

        }

        public DBWebsite(DbContextOptions<DBWebsite> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EducationalProgram program1 = new EducationalProgram { Id = 1, Name = "ASP.NET Core 7" };
            EducationalProgram program2 = new EducationalProgram { Id = 2, Name = "PHP" };
            EducationalProgram program3 = new EducationalProgram { Id = 3, Name = "Java" };

            Child child1 = new Child { Id = 1, ProgramId = 1, FirstName = "Igor", LastName = "Radchuk", Status = Status.IsStudying };
            Child child2 = new Child { Id = 2, ProgramId = 1, FirstName = "Petro", LastName = "Ostapchuk", Status = Status.IsStudying };
            Child child3 = new Child { Id = 3, ProgramId = 1, FirstName = "Ivan", LastName = "Chug", Status = Status.IsStudying };
            Child child4 = new Child { Id = 4, ProgramId = 1, FirstName = "Andriy", LastName = "Oshuta", Status = Status.IsStudying };
            Child child5 = new Child { Id = 5, ProgramId = 1, FirstName = "Nazar", LastName = "Melnyk", Status = Status.IsStudying };
            Child child6 = new Child { Id = 6, ProgramId = 1, FirstName = "Dmitro", LastName = "Honchar", Status = Status.IsStudying };
            Child child7 = new Child { Id = 7, ProgramId = 1, FirstName = "Stepan", LastName = "Bandera", Status = Status.IsStudying };
            Child child8 = new Child { Id = 8, ProgramId = 1, FirstName = "Taras", LastName = "Shevchenko", Status = Status.IsStudying };

            modelBuilder.Entity<EducationalProgram>().HasData(program1, program2, program3);
            modelBuilder.Entity<Child>().HasData(child1, child2, child3, child4, child5, child6, child7, child8);


            modelBuilder
               .Entity<Child>()
               .HasOne(x => x.Program)
               .WithMany(x => x.Children)
               .HasForeignKey(x=>x.ProgramId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
