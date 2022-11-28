using ChildDevelopmentLibrary;
using ChildDevelopmentLibrary.Interfaces;
using ChildDevelopmentLibrary.Models;
using Couchbase.Core.Exceptions;
using Moq;
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
        public void GetChildrenByStatus_MustDoesNotContainThroughPeriod()
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
    }
}
