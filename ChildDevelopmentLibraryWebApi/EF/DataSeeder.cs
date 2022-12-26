using ChildDevelopmentLibrary.DAL.DBContext;
using ChildDevelopmentLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildDevelopmentLibraryWebApi.Entities
{
    public class DataSeeder
    {
        private readonly DBWebsite context;

        public DataSeeder(DBWebsite context)
        {
            this.context = context;
        }

        public void Initial()
        {
            EducationalProgram program1 = new EducationalProgram { Id = 1, Name = "ASP.NET Core 7" };
            EducationalProgram program2 = new EducationalProgram { Id = 2, Name = "PHP" };
            EducationalProgram program3 = new EducationalProgram { Id = 3, Name = "Java" };

            if (!context.Children.Any())
            {
                context.AddRange(program1, program2, program3);
                context.SaveChanges();
            }

            if (!context.Children.Any())
            {
                context.AddRange(
                new Child { Id = 1, Program = program1, FirstName = "Igor", LastName = "Radchuk", Status = Status.IsStudying },
                new Child { Id = 2, Program = program1, FirstName = "Petro", LastName = "Ostapchuk", Status = Status.IsStudying },
                new Child { Id = 3, Program = program1, FirstName = "Ivan", LastName = "Chug", Status = Status.IsStudying },
                new Child { Id = 4, Program = program1, FirstName = "Andriy", LastName = "Oshuta", Status = Status.IsStudying },
                new Child { Id = 5, Program = program1, FirstName = "Nazar", LastName = "Melnyk", Status = Status.IsStudying },
                new Child { Id = 6, Program = program1, FirstName = "Dmitro", LastName = "Honchar", Status = Status.IsStudying },
                new Child { Id = 7, Program = program1, FirstName = "Stepan", LastName = "Bandera", Status = Status.IsStudying },
                new Child { Id = 8, Program = program1, FirstName = "Taras", LastName = "Shevchenko", Status = Status.IsStudying }
                );
                context.SaveChanges();
            }
        }
    }
}
