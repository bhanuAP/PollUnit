using System;
using System.Collections.Generic;
using System.Linq;
using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.UserService.Interface;
using Newtonsoft.Json;
using Polling.Unit.Repository.DBTableObjects;
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
            bool createAccount = _dataService.CreateUser(userName, password);
            UserDTO dto = new UserDTO();
            dto.userName = userName;
            if (createAccount)
            {
                dto.message = "Your Account Has Created";
                dto.url = "/login";
                return dto;
            }
            dto.message = "User Name Already Exists";
            dto.url = "/createAccount";
            return dto;
        }

        public UserDTO LoginAccount(string userName, string password)
        {
            UserInfo userInfo = _dataService.GetUserInfo(userName);
            UserDTO dto = new UserDTO();
            dto.userName = userName;
            //if (userInfo != null)
            //{
            //    if (userInfo.PASSWORD == password)
            //    {
            //        dto.url = "/home";
            //        dto.message = "Welcome!, " + userName;
            //        return dto;
            //    }
            //    dto.message = "User Name And Password Doesn't Match";
            //    dto.url = "/login";
            //    return dto;
            //}
            //dto.url = "/login";
            //dto.message = "User Name Doesn't Exists";
            return dto;
        }
    }
}
