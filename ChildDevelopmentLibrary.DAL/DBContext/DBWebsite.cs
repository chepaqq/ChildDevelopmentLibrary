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


            modelBuilder
               .Entity<Child>()
               .HasOne(x => x.Program)
               .WithMany(x => x.Children)
               .HasForeignKey(x=>x.ProgramId);

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<EducationalProgram>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
