using ChildDevelopmentLibrary;
using System;
using System.Collections.Generic;
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
    }
}
