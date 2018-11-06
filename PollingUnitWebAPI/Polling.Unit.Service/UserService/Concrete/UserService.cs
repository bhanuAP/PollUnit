using Polling.Unit.Repository.DataTransmittingObject;
using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.UserService.Interface;

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
            return _dataService.CreateUser(userName, password);
        }
    }
}
