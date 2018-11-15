using System.Collections.Generic;
using Polling.Unit.Repository.DBTableObjects;

namespace Polling.Unit.Repository.UserDataRepository.Interface
{
    public interface IUserDataRepository
    {
        bool CreateUser(string userID, string password);
        UserInfo GetUserInfo(string userName);
    }
}
