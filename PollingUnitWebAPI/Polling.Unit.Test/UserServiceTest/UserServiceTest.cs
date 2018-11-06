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
            UserDTO userDTO = new UserDTO();
            userDTO.userName = userName;
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Returns(userDTO);
            UserService service = new UserService(repository.Object);
            service.CreateAccount(userName, password);
            repository.Verify(m => m.CreateUser(userName, password), Times.Once);
        }

        [Fact]
        public void ShouldReturnUserDtoWithUserNameForValidUser()
        {
            string userName = "Bhanu";
            string password = "xyz";
            UserDTO expectedDTO = new UserDTO();
            expectedDTO.userName = userName;
            expectedDTO.hasAccount = true;
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Returns(expectedDTO);
            UserService service = new UserService(repository.Object);
            UserDTO userDto = service.CreateAccount(userName, password);
            userDto.Equals(expectedDTO);
        }
    }
}

