using ChildDevelopmentLibrary;
using ChildDevelopmentLibrary.Interfaces;
using ChildDevelopmentLibrary.Models;
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

            var sut = new Moq.Mock<IDBWebsite>();

            sut.Setup(x => x.Children).Returns(new List<Child> { child });

            var sutWebsite = new EducationalWebsite(sut.Object);

            //Act + Assert          
            Assert.Contains(child, sutWebsite.GetChildrenByPeriod(Status.Signed));
        }

        [Fact]
        public void GetChildrenByPeriod_MustDoesNotContainThroughPeriod()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };

            var sut = new Moq.Mock<IDBWebsite>();

            sut.Setup(x => x.Children).Returns(new List<Child> { child });

            var sutWebsite = new EducationalWebsite(sut.Object);

            //Act 
            child.Status = Status.IsStudying;

            //Assert
            Assert.DoesNotContain(child, sutWebsite.GetChildrenByPeriod(Status.Signed));
        }
    }
}
