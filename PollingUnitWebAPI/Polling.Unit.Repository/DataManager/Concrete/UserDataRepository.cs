using Polling.Unit.Repository.Context;
using Polling.Unit.Repository.DataTransmittingObject;
using Polling.Unit.Repository.UserDataRepository.Interface;
using System;
using Polling.Unit.Repository.DBTableObjects;

namespace Polling.Unit.Repository.UserDataRepository.Concrete
{
    public class UserDataRepository : IUserDataRepository
    {
        private PollingUnitContext _dbContext { get; }

        public UserDataRepository(PollingUnitContext context)
        {
            _dbContext = context;
        }

        public UserDTO CreateUser(string userID, string password)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.USER_NAME = userID;
            userInfo.PASSWORD = password;
            UserDTO resultUserDto = new UserDTO();
            resultUserDto.userName = userID;
            resultUserDto.hasAccount = false;
            try
            {
                _dbContext.USER_INFO.Add(userInfo);
                _dbContext.SaveChanges();
                resultUserDto.hasAccount = true;
            }
            catch (Exception e)
            {
                throw new Exception("User Name Already Exists");
            }
            return resultUserDto;
        }
    }
}
