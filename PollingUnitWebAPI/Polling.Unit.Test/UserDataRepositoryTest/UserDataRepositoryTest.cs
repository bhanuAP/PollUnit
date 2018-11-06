using Microsoft.EntityFrameworkCore;
using Moq;
using Polling.Unit.Repository.Context;
using Polling.Unit.Repository.DataTransmittingObject;
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
        public void ShouldReturnExpectedUserDTOAfterCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "abc";
            UserDTO expectedDto = new UserDTO();
            expectedDto.userName = userName;
            expectedDto.hasAccount = true;
            DbContextOptions<PollingUnitContext> contextOptions = new DbContextOptions<PollingUnitContext>();
            var mockSet = new Mock<DbSet<UserInfo>>();
            var mockContext = new Mock<PollingUnitContext>(contextOptions);
            mockContext.Setup(m => m.USER_INFO).Returns(mockSet.Object);
            UserDataRepository repository = new UserDataRepository(mockContext.Object);

            UserDTO dto = repository.CreateUser(userName, password);

            dto.Equals(expectedDto);
        }
    }
}
