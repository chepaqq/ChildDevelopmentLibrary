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
        public void GetChildrenByPeriod_MustContains()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Children.Add(child);

            //Assert          
            Assert.Contains(child, sub.GetChildrenByPeriod(sub.Children, Period.Signed));
        }

        [Fact]
        public void GetChildrenByPeriod_MustExeptionNullReferenceByChildren()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);
            sub.Children.Add(child);
            child.Period = Period.IsStudying;

            //Assert
            Assert.Throws<Exception>(() => sub.GetChildrenByPeriod(null, Period.Signed));
        }

        [Fact]
        public void GetChildrenByPeriod_MustExeptionNullReferenceByPeriod()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);
            sub.Children.Add(child);
            child.Period = Period.IsStudying;

            //Assert
            Assert.DoesNotContain(child, sub.GetChildrenByPeriod(sub.Children, Period.Signed));
        }
    }
}
