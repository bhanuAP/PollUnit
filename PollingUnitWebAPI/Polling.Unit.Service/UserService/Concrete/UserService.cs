using System;
using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.UserService.Interface;
using Newtonsoft.Json;
using Polling.Unit.Service.DataTransmittingObject;

namespace Polling.Unit.Service.UserService.Concrete
{
    public class UserService: IUserService
    {
        private IUserDataRepository _dataService;

        public UserService(IUserDataRepository dataService)
        {
            _dataService = dataService;
        }

        public UserDTO CreateAccount(string userName, string password)
        {
            try
            {
                _dataService.CreateUser(userName, password);
                UserDTO dto = new UserDTO();
                dto.userName = userName;
                dto.message = "Your Account Created";
                dto.url = "/login";
                return dto;
            }
            catch (Exception e)
            {
                UserDTO dto = new UserDTO();
                dto.userName = userName;
                dto.message = e.Message;
                dto.url = "/createAccount";
                return dto;
            }
        }

        public class ResponseObject
        {
            public string message { get; set; }
            public string url { get; set; }

            public override string ToString() => "message: " + message + ", url: " + url;
        }
    }
}
