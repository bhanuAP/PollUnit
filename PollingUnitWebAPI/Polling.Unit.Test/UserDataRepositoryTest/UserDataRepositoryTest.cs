using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using Polling.Unit.Repository.Context;
using Polling.Unit.Repository.DBTableObjects;
using Polling.Unit.Repository.UserDataRepository.Concrete;
using Xunit;

namespace Polling.Unit.Test.UserDataRepositoryTest
{
    public class UserDataRepositoryTest
    {
        [Fact]
        public void ShouldCallExpectedMethosForCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "abc";
            DbContextOptions<PollingUnitContext> contextOptions = new DbContextOptions<PollingUnitContext>();
            var mockSet = new Mock<DbSet<UserInfo>>();
            var mockContext = new Mock<PollingUnitContext>(contextOptions);
            mockContext.Setup(m => m.USER_INFO).Returns(mockSet.Object);

            UserDataRepository repository = new UserDataRepository(mockContext.Object);
            repository.CreateUser(userName, password);
            
            mockSet.Verify(m => m.Add(It.IsAny<UserInfo>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void ShouldreturnTrueAfterCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "abc";
            DbContextOptions<PollingUnitContext> contextOptions = new DbContextOptions<PollingUnitContext>();
            var mockSet = new Mock<DbSet<UserInfo>>();
            var mockContext = new Mock<PollingUnitContext>(contextOptions);
            mockContext.Setup(m => m.USER_INFO).Returns(mockSet.Object);

            UserDataRepository repository = new UserDataRepository(mockContext.Object);
            bool result = repository.CreateUser(userName, password);

            Assert.Equal(true, result);
        }

        [Fact]
        public void ShouldreturnFalseAfterCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "abc";
            DbContextOptions<PollingUnitContext> contextOptions = new DbContextOptions<PollingUnitContext>();
            var mockSet = new Mock<DbSet<UserInfo>>();
            var mockContext = new Mock<PollingUnitContext>(contextOptions);
            mockContext.Setup(m => m.USER_INFO).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Throws(new Exception());

            UserDataRepository repository = new UserDataRepository(mockContext.Object);
            bool result = repository.CreateUser(userName, password);

            Assert.Equal(false, result);
        }

        [Fact]
        public void ShouldCallExpectedMethosForLoggingInUserAccount()
        {
            string userName = "Bhanu";
            string password = "abc";
            DbContextOptions<PollingUnitContext> contextOptions = new DbContextOptions<PollingUnitContext>();
            var mockSet = new Mock<DbSet<UserInfo>>();
            var mockContext = new Mock<PollingUnitContext>(contextOptions);
            mockContext.Setup(m => m.USER_INFO).Returns(mockSet.Object);

            UserDataRepository repository = new UserDataRepository(mockContext.Object);
            repository.CreateUser(userName, password);

            mockSet.Verify(m => m.Add(It.IsAny<UserInfo>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
