using System;
using FsCheck;
using Moq;
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
        public void ShouldCallRepositoryMethod()
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
            expectedUserDto.message = "Your Account Created";
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            repository.Setup(m => m.CreateUser(userName, password)).Verifiable();

            UserService service = new UserService(repository.Object);
            UserDTO result = service.CreateAccount(userName, password);

            result.Equals(expectedUserDto).ShouldBe(true);
        }

        [Fact]
        public void ShouldReturnExpectedObjectForErrorInCreatingUserAccount()
        {
            string userName = "Bhanu";
            string password = "xyz";
            string exceptionMessage = "User Name Already Exists";
            UserDTO expectedUserDto = new UserDTO();
            expectedUserDto.userName = userName;
            expectedUserDto.url = "/createAccount";
            expectedUserDto.message = exceptionMessage;
            Mock<IUserDataRepository> repository = new Mock<IUserDataRepository>();
            var exception = new Exception(exceptionMessage);
            repository.Setup(m => m.CreateUser(userName, password)).Throws(exception);

            UserService service = new UserService(repository.Object);
            UserDTO result = service.CreateAccount(userName, password);

            result.Equals(expectedUserDto).ShouldBe(true);
        }
    }
}

