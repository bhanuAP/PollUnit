using Moq;
using Polling.Unit.Repository.DataTransmittingObject;
using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.UserService.Concrete;
using Xunit;

namespace Polling.Unit.Test.UserServiceTest
{
    public class UserServiceTest
    {
        [Fact]
        public void ShouldCallRepositoryMethod()
        {
            string userName = "Bhanu";
            string password = "xyz";
            UserDTO userDto = new UserDTO();
            userDto.userName = userName;
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Verifiable();

            UserService service = new UserService(repository.Object);
            service.CreateAccount(userName, password);

            repository.Verify(m => m.CreateUser(userName, password), Times.Once);
        }
    }
}

