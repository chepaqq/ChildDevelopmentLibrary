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
        public DbSet<EducationalProgram> Programs { get; set; } = null!;
        public DbSet<Child> Children { get; set; } = null!;

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

            Child child1 = new Child { Id = 1, ProgramId = 1, FirstName = "Igor", LastName = "Radchuk" };
            Child child2 = new Child { Id = 2, ProgramId = 1, FirstName = "Petro", LastName = "Ostap" };

            modelBuilder.Entity<EducationalProgram>().HasData(program1, program2);
            modelBuilder.Entity<Child>().HasData(child1, child2);


            modelBuilder
               .Entity<Child>()
               .HasOne(x => x.Program)
               .WithMany(x => x.Children)
               .HasForeignKey("ProgramId")
               .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
