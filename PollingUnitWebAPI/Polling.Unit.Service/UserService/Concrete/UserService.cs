using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.UserService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polling.Unit.Service.UserService.Interface
{
    public class UserService: IUserService
    {
        private IUserDataRepository _dataService;

        public UserService(IUserDataRepository dataService)
        {
            _dataService = dataService;
        }
    }
}
