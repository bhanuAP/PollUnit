using Polling.Unit.Repository.Context;
using Polling.Unit.Repository.UserDataRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool CreateUser(string userID, string password)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.USER_NAME = userID;
            userInfo.PASSWORD = password;
            try
            {
                _dbContext.USER_INFO.Add(userInfo);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public UserInfo GetUserInfo(string userID)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.USER_NAME = userID;
            try
            {
                IEnumerable<UserInfo> users = _dbContext.USER_INFO
                    .Where(tableValues => tableValues.USER_NAME == userID)
                    .ToList();
                _dbContext.SaveChanges();
                return users.ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
