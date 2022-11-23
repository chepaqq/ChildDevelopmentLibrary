using ChildDevelopmentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeMock;
using Moq;
using Xunit;
using TypeMock.ArrangeActAssert;

namespace ChildDevelopmentLibraryTest
{
    public class EducationalWebsiteTest
    {
        [Fact]
        public void SubscribeToProgram_MustContains()
        {
            //Arrange
            var sut = new Moq.Mock<IEducationalWebsite>();
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            Program program = new Program { Name = "ASP.NET Core 7.0" };

            //Act
            sut.Setup(x => x.Children).Returns(new List<Child> { child });

            sut.Setup(x => x.Programs).Returns(new List<Program> { new Program {
                Name = "ASP.NET Core 7.0",
                Children = new List<Child> { child }
            } });

            sut.Object.SubscribeToProgram(child, program);

            //Assert
            Assert.Contains(child, sut.Object.Programs
                .Where(x => x.Name == program.Name).Single().Children);
        }

        [Fact]
        public void SubscribeToProgram_MustBeErrorInSubscribeToProgram()
        {
            //Arrange
            var sut = new Moq.Mock<EducationalWebsite>();
            var child = new Child();
            child.Status = Status.IsStudying;

            //Assert
            Assert.Throws<Exception>(() => sut.Object.SubscribeToProgram(child, null));
        }

        [Fact]
        public void SubscribeToProgram_MustBeNullExceptionThroughTheChild()
        {
            //Arrange
            Program program = new Program { Name = "ASP.NET Core 7.0" };
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act        
            sut.Setup(x => x.SubscribeToProgram(It.IsAny<Child>(), It.IsAny<Program>()))
                .Throws(new Exception());

            //Assert
            Assert.Throws<Exception>(() => sut.Object.SubscribeToProgram(null, program));
        }

        [Fact]
        public void SubscribeToProgram_MustBeNullExceptionThroughTheProgram()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act        
            sut.Setup(x => x.SubscribeToProgram(It.IsAny<Child>(), It.IsAny<Program>()))
                .Throws(new Exception());

            //Assert
            Assert.Throws<Exception>(() => sut.Object.SubscribeToProgram(child, null));
        }
    }
}
