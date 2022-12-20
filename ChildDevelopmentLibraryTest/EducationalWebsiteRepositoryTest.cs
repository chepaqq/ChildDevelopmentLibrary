using Couchbase.Core.Exceptions;
using Moq;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.DBContext;
using ChildDevelopmentLibrary.BLL.Repository;
using Microsoft.EntityFrameworkCore;

namespace ChildDevelopmentLibraryTest
{
    public class EducationalWebsiteRepositoryTest
    {
        [Fact]
        public async void GetChildrenByStatus_MustContains()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsiteRepository>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
                 .ReturnsAsync(new List<Child> { child });

            //Assert
            Assert.Contains(child, await sut.Object.GetChildrenByStatus(Status.CompletedStudies));
        }

        [Fact]
        public async void GetChildrenByStatus_MustDoesNotContainThroughStatus()
        {
            //Arrange
            Child child = new Child { FirstName = "Igor", LastName = "Radchuk" };
            var sut = new Moq.Mock<IEducationalWebsiteRepository>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
               .ReturnsAsync(new List<Child>
               { new Child { FirstName = "Igor", LastName = "Radchuk", Status= Status.IsStudying }});

            //Assert
            Assert.DoesNotContain(child, await sut.Object.GetChildrenByStatus(Status.IsStudying));
        }

        [Fact]
        public async void GetChildrenByStatus_MustNullExeptionThroughChildren()
        {
            //Arrange
            var sut = new Moq.Mock<IEducationalWebsiteRepository>();

            //Act
            sut.Setup(x => x.GetChildrenByStatus(It.IsAny<Status>()))
              .ThrowsAsync(new InvalidArgumentException());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.Object.GetChildrenByStatus(Status.Signed));
        }

        //-----------SubscribeToProgram------------
        [Fact]
        public async void SubscribeToProgram_MustBeErrorThroughDatabase()
        {
            //Arrange
            var sutDb = new Moq.Mock<DBWebsite>();
            var sutWebsite = new EducationalWebsiteRepository(sutDb.Object);

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sutWebsite.SubscribeToProgram(1, 1));
        }

        [Fact]
        public async void SubscribeToProgram_MustBeErrorInSubscribeThroughChildId()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.SubscribeToProgram(-1, 1));
        }

        [Fact]
        public async void SubscribeToProgram_MustBeErrorInSubscribeThroughProgramId()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.SubscribeToProgram(1, 0));
        }

        //-----------StartStudying------------
        [Fact]
        public async void StartStudying_MustBeErrorThroughDatabase()
        {
            //Arrange
            var sutDb = new Moq.Mock<DBWebsite>();
            var sutWebsite = new EducationalWebsiteRepository(sutDb.Object);

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sutWebsite.StartStudying(1, 1));
        }

        [Fact]
        public async void StartStudying_MustBeErrorInSubscribeThroughChildId()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.StartStudying(-1, 1));
        }

        [Fact]
        public async void StartStudying_MustBeErrorInSubscribeThroughProgramId()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.StartStudying(1, -2));
        }

        //-----------CompleteStudying------------
        [Fact]
        public async void CompleteStudying_MustBeErrorThroughDatabase()
        {
            //Arrange
            var sutDb = new Moq.Mock<DBWebsite>();
            var sutWebsite = new EducationalWebsiteRepository(sutDb.Object);

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sutWebsite.CompleteStudying(1, 1));
        }

        [Fact]
        public async void CompleteStudying_MustBeErrorInSubscribeThroughChildId()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.CompleteStudying(-1, 1));
        }

        [Fact]
        public async void CompleteStudying_MustBeErrorInSubscribeThroughProgramId()
        {
            //Arrange
            var sut = new EducationalWebsiteRepository(new DBWebsite());

            //Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => sut.CompleteStudying(1, -2));
        }

    }
}
