using Polling.Unit.Repository.DataTransmittingObject;

namespace Polling.Unit.Repository.UserDataRepository.Interface
{
    public interface IUserDataRepository
    {
        void CreateUser(string userID, string password);
    }
}
