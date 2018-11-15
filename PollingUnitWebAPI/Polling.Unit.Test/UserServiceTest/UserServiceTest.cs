using Moq;
using Polling.Unit.Repository.DBTableObjects;
using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.DataTransmittingObject;
using Polling.Unit.Service.UserService.Concrete;
using Shouldly;
using Xunit;

namespace Polling.Unit.Test.UserServiceTest
{
    public class UserServiceTest
    {
        [Fact]
        public void ShouldCallExpectedRepositoryMethodForCreatingAccount()
        {
            string userName = "Bhanu";
            string password = "xyz";
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Verifiable();

            UserService service = new UserService(repository.Object);
            service.CreateAccount(userName, password);

            repository.Verify(m => m.CreateUser(userName, password), Times.Once);
        }

        [Fact]
        public void ShouldReturnExpectedObjectAfterCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "xyz";
            UserDTO expectedUserDto = new UserDTO();
            expectedUserDto.userName = userName;
            expectedUserDto.url = "/login";
            expectedUserDto.message = "Your Account Has Created";
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Returns(true);

            UserService service = new UserService(repository.Object);
            UserDTO result = service.CreateAccount(userName, password);

            result.Equals(expectedUserDto).ShouldBe(true);
        }

        [Fact]
        public void ShouldReturnExpectedObjectForErrorInCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "xyz";
            string errorMessage = "User Name Already Exists";
            UserDTO expectedUserDto = new UserDTO();
            expectedUserDto.userName = userName;
            expectedUserDto.url = "/createAccount";
            expectedUserDto.message = errorMessage;
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Returns(false);

            UserService service = new UserService(repository.Object);
            UserDTO result = service.CreateAccount(userName, password);

            result.Equals(expectedUserDto).ShouldBe(true);
        }

        [Fact]
        public void ShouldCallExpectedRepositoryMethodForAccountLogin()
        {
            string userName = "Bhanu";
            string password = "xyz";
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.GetUserInfo(userName)).Verifiable();

            UserService service = new UserService(repository.Object);
            service.LoginAccount(userName, password);

            repository.Verify(m => m.GetUserInfo(userName), Times.Once);
        }

        [Fact]
        public void ShouldReturnExpectedDtoForValidUserCredentials()
        {
            string userName = "Bhanu";
            string password = "xyz";
            UserInfo userInfo = new UserInfo();
            userInfo.USER_NAME = userName;
            userInfo.PASSWORD = password;
            UserDTO expectedDto = new UserDTO();
            expectedDto.userName = userName;
            expectedDto.url = "/home";
            expectedDto.message = "Welcome!, " + userName;
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.GetUserInfo(userName)).Returns(userInfo);   

            UserService service = new UserService(repository.Object);
            UserDTO result = service.LoginAccount(userName, password);

            result.Equals(expectedDto).ShouldBe(true);
        }

        [Fact]
        public void ShouldReturnExpectedDtoForInValidUserCredentials()
        {
            string userName = "Bhanu";
            string password = "xyz";
            UserInfo userInfo = new UserInfo();
            userInfo.USER_NAME = userName;
            userInfo.PASSWORD = "";
            UserDTO expectedDto = new UserDTO();
            expectedDto.userName = userName;
            expectedDto.url = "/login";
            expectedDto.message = "User Name And Password Doesn't Match";
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.GetUserInfo(userName)).Returns(userInfo);

            UserService service = new UserService(repository.Object);
            UserDTO result = service.LoginAccount(userName, password);

            result.Equals(expectedDto).ShouldBe(true);
        }

        [Fact]
        public void ShouldReturnExpectedDtoForInValidUserAccount()
        {
            string userName = "Bhanu";
            string password = "xyz";
            UserDTO expectedDto = new UserDTO();
            expectedDto.userName = userName;
            expectedDto.url = "/login";
            expectedDto.message = "User Name Doesn't Exists";
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();

            UserService service = new UserService(repository.Object);
            UserDTO result = service.LoginAccount(userName, password);

            result.Equals(expectedDto).ShouldBe(true);
        }
    }
}
