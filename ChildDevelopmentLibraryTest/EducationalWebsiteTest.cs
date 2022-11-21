using ChildDevelopmentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChildDevelopmentLibraryTest
{
    public class EducationalWebsiteTest
    {
        [Fact]
        public void SubscribeToProgram_MustBeEqual()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite {Name="WebSite"};

            //Act
            sub.Programs.Add(program);
            sub.Children.Add(child);
            sub.SubscribeToProgram(child, program);

            //Assert          
            Assert.Contains(child, sub.Programs.Where(x => x.Name == program.Name).Single().Children);
        }

        [Fact]
        public void SubscribeToProgram_MustBeErrorInSubscribeToProgram()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);
            sub.Children.Add(child);
            child.IsStudied = true;

            //Assert
            Assert.Throws<Exception>(()=> sub.SubscribeToProgram(child, program));
        }

        [Fact]
        public void SubscribeToProgram_MustBeArgumentNullExceptionThroughTheChild()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);

            //Assert
            Assert.Throws<Exception>(() => sub.SubscribeToProgram(child, program));
        }

        [Fact]
        public void SubscribeToProgram_MustBeArgumentNullExceptionThroughTheProgram()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Children.Add(child);

            //Assert
            Assert.Throws<Exception>(() => sub.SubscribeToProgram(child, program));
        }
    }
}
