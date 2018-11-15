using Polling.Unit.Service.DataTransmittingObject;

namespace Polling.Unit.Service.UserService.Interface
{
    public interface IUserService
    {
        UserDTO CreateAccount(string userName, string password);
        UserDTO LoginAccount(string userName, string password);
    }
}
