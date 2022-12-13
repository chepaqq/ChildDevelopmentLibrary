using ChildDevelopmentLibrary;
using ChildDevelopmentLibrary.Interfaces;
using ChildDevelopmentLibrary.Models;
using Couchbase.Core.Exceptions;
using Moq;
using System;
using System.Linq;
using System.Text;
using TypeMock;
using Moq;
using Mock;
using Xunit;
using TypeMock.ArrangeActAssert;
using ChildDevelopmentLibrary.Interfaces;
using Couchbase.Core.Exceptions;

namespace ChildDevelopmentLibraryTest
{
    public class EducationalWebsiteTest
    {
        [Fact]
        public void GetChildrenByStatus_MustContains()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
                 .Returns(new List<Child> { child });

            //Assert          
            Assert.Contains(child, sut.Object.GetChildrenByStatus(Status.Signed));
        }

        [Fact]
        public void GetChildrenByStatus_MustDoesNotContainThroughStatus()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
               .Returns(new List<Child>
               { new Child { FirstName = "Igor", LastName = "Radchuk", Status= Status.IsStudying }});

            //Assert
            Assert.DoesNotContain(child, sut.Object.GetChildrenByStatus(Status.Signed));
        }

        [Fact]
        public void GetChildrenByStatus_MustNullExeptionThroughChildren()
        {
            //Arrange
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
              .Throws(new InvalidArgumentException());

            //Assert
            Assert.Throws<InvalidArgumentException>(() => sut.Object.GetChildrenByStatus(Status.Signed));
        }

        [Fact]
        public void SubscribeToProgram_MustBeErrorInSubscribeToProgram()
        {
            //Arrange
            var sut = new EducationalWebsite(new DBWebsite());
            var child = new Child();
            child.Status = Status.IsStudying;

            //Assert
            Assert.Throws<InvalidArgumentException>(() => sut.SubscribeToProgram(child, null));
        }

        [Fact]
        public void SubscribeToProgram_MustBeNullExceptionThroughTheChild()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };

            var sut = new Moq.Mock<IDBWebsite>();

            sut.Setup(x => x.Children).Returns(new List<Child>());
            sut.Setup(x => x.Programs).Returns(new List<Program> { new Program {
                    Name = "ASP.NET Core 7.0",
                    Children = new List<Child> { child }
                } });

            var sutWebsite = new EducationalWebsite(sut.Object);

            //Act + Assert
            Assert.Throws<InvalidArgumentException>(() => sutWebsite.SubscribeToProgram(child, program));
        }

        [Fact]
        public void SubscribeToProgram_MustBeNullExceptionThroughTheProgram()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };

            var sut = new Moq.Mock<IDBWebsite>();

            sut.Setup(x => x.Children).Returns(new List<Child> { child });
            sut.Setup(x => x.Programs).Returns(new List<Program>());

            var sutWebsite = new EducationalWebsite(sut.Object);

            //Act + Assert
            Assert.Throws<InvalidArgumentException>(() => sutWebsite.SubscribeToProgram(child, program));
        }
        [Fact]
        public void StartStudying_MustBeEqual()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);
            sub.Children.Add(child);
            sub.SubscribeToProgram(child, program);
            sub.StartStudying(child, program);

            //Assert          
            Assert.Contains(child, sub.Programs.Where(x => x.Name == program.Name).Single().Children);
            Assert.Equal(Status.IsStudying, sub.Programs
                .Where(x => x.Name == program.Name).Single()
                .Children
                .Where(x => x.FirstName == child.FirstName && x.LastName == child.LastName)
                .Single().Status);
        }

        [Fact]
        public void StartStudying_MustBeErrorInSubscribeToProgram()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);
            sub.Children.Add(child);
            child.Status = Status.IsStudying;

            //Assert
            Assert.Throws<Exception>(() => sub.StartStudying(child, program));
        }

        [Fact]
        public void StartStudying_MustBeArgumentNullExceptionThroughTheChild()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Programs.Add(program);

            //Assert
            Assert.Throws<Exception>(() => sub.StartStudying(child, program));
        }

        [Fact]
        public void StartStudying_MustBeArgumentNullExceptionThroughTheProgram()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            EducationalWebsite sub = new EducationalWebsite { Name = "WebSite" };

            //Act
            sub.Children.Add(child);

            //Assert
            Assert.Throws<Exception>(() => sub.StartStudying(child, program));
        }
    }
}
