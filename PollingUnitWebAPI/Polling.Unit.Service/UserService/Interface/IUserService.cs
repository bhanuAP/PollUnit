using Polling.Unit.Repository.DataTransmittingObject;

namespace Polling.Unit.Service.UserService.Interface
{
    public interface IUserService
    {
        UserDTO CreateAccount(string userName, string password);
    }
}
