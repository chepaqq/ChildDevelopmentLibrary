using ChildDevelopmentLibrary;
using ChildDevelopmentLibrary.Models;
using Couchbase.Core.Exceptions;
using Moq;
using System;
using System.Linq;
using System.Text;
using TypeMock;
using Mock;
using Xunit;
using TypeMock.ArrangeActAssert;
using System.Collections.Generic;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.Interfaces;
using ChildDevelopmentLibrary.DAL.DBContext;
using ChildDevelopmentLibrary.BLL.Repository;
using Microsoft.EntityFrameworkCore;

namespace ChildDevelopmentLibraryTest
{
    public class EducationalWebsiteTest
    {
        [Fact]
        public void GetChildrenByStatus_MustContains()
        {
            //Arrange
            ChildDto child = new ChildDto { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsiteRepository>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
                 .Returns(new List<ChildDto> { child });

            //Assert          
            Assert.Contains(child, sut.Object.GetChildrenByStatus(Status.Signed));
        }

        [Fact]
        public void GetChildrenByStatus_MustDoesNotContainThroughStatus()
        {
            //Arrange
            ChildDto child = new ChildDto { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsiteRepository>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
               .Returns(new List<ChildDto>
               { new ChildDto { FirstName = "Igor", LastName = "Radchuk", Status= Status.IsStudying }});

            //Assert
            Assert.DoesNotContain(child, sut.Object.GetChildrenByStatus(Status.Signed));
        }

        [Fact]
        public void GetChildrenByStatus_MustNullExeptionThroughChildren()
        {
            //Arrange
            var sut = new Moq.Mock<IEducationalWebsiteRepository>();

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
            var sut = new EducationalWebsiteRepository(new DBWebsite());
            var child = new ChildDto();
            child.Status = Status.IsStudying;

            //Assert
            Assert.Throws<InvalidArgumentException>(() => sut.SubscribeToProgram(child, null));
        }

        [Fact]
        public void SubscribeToProgram_MustBeNullExceptionThroughEmptyDatabase()
        {
            //Arrange
            ChildDto childDto = new ChildDto { FirstName = "Igor", LastName = "Radchuk" };
            EducationalProgramDto programDto = new EducationalProgramDto { Name = "ASP.NET Core 7.0" };
            DBWebsite dBWebsite = new DBWebsite();

            var sut = new Moq.Mock<IDBWebsite>();

            var sutWebsite = new EducationalWebsiteRepository(sut.Object);

            //Act + Assert
            Assert.Throws<InvalidArgumentException>(() => sutWebsite.SubscribeToProgram(childDto, programDto));
        }
       
        [Fact]
        public void StartStudying_MustBeErrorInStartStudying()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());
            var child = new ChildDto();
            child.Status = Status.IsStudying;

            //Assert
            Assert.Throws<InvalidArgumentException>(() => sut.StartStudying(child, null));
        }

        [Fact]
        public void StartStudying_MustBeNullExceptionThroughEmptyDatabase()
        {
            //Arrange
            ChildDto childDto = new ChildDto { FirstName = "Igor", LastName = "Radchuk" };
            EducationalProgramDto programDto = new EducationalProgramDto { Name = "ASP.NET Core 7.0" };
            DBWebsite dBWebsite = new DBWebsite();

            var sut = new Moq.Mock<IDBWebsite>();

            var sutWebsite = new EducationalWebsiteRepository(sut.Object);

            //Act + Assert
            Assert.Throws<InvalidArgumentException>(() => sutWebsite.StartStudying(childDto, programDto));
        }

        [Fact]
        public void CompleteStudying_MustBeErrorInCompleteStudying()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());
            var child = new ChildDto();
            child.Status = Status.CompletedStudies;

            //Assert
            Assert.Throws<InvalidArgumentException>(() => sut.CompleteStudying(child, null));
        }

        [Fact]
        public void CompleteStudying_MustBeNullExceptionThroughEmptyDatabase()
        {
            //Arrange
            ChildDto childDto = new ChildDto { FirstName = "Igor", LastName = "Radchuk" };
            EducationalProgramDto programDto = new EducationalProgramDto { Name = "ASP.NET Core 7.0" };
            DBWebsite dBWebsite = new DBWebsite();

            var sut = new Moq.Mock<IDBWebsite>();

            var sutWebsite = new EducationalWebsiteRepository(sut.Object);

            //Act + Assert
            Assert.Throws<InvalidArgumentException>(() => sutWebsite.CompleteStudying(childDto, programDto));
        }

    }
}
