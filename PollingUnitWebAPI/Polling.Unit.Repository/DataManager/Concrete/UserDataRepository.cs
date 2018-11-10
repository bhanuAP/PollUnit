using Polling.Unit.Repository.Context;
using Polling.Unit.Repository.UserDataRepository.Interface;
using System;
using System.Net.Http;
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

        public void CreateUser(string userID, string password)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.USER_NAME = userID;
            userInfo.PASSWORD = password;
            try
            {
                _dbContext.USER_INFO.Add(userInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("User Name Already Exists");
            }
        }
    }
}
