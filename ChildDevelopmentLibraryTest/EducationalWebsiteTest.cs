using ChildDevelopmentLibrary;
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
        public void GetChildrenByPeriod_MustContains()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act
            sut.Setup(x => x.GetChildrenByPeriod(It.IsAny<Status>()))
                .Returns(new List<Child> { child });

            //Assert          
            Assert.Contains(child, sut.Object.GetChildrenByPeriod(Status.Signed));
        }

        [Fact]
        public void GetChildrenByPeriod_MustDoesNotContainThroughPeriod()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act
            sut.Setup(x => x.GetChildrenByPeriod(It.IsAny<Status>()))
               .Returns(new List<Child>
               { new Child { FirstName = "Igor", LastName = "Radchuk", Status= Status.IsStudying }});

            //Assert
            Assert.DoesNotContain(child, sut.Object.GetChildrenByPeriod(Status.Signed));
        }

        [Fact]
        public void GetChildrenByPeriod_MustNullExeptionThroughChildren()
        {
            //Arrange
            var sut = new Moq.Mock<IEducationalWebsite>();

            //Act
            sut.Setup(x => x.GetChildrenByPeriod(It.IsAny<Status>()))
              .Throws(new Exception());

            //Assert
            Assert.Throws<Exception>(() => sut.Object.GetChildrenByPeriod(Status.Signed));
        }
    }
}
