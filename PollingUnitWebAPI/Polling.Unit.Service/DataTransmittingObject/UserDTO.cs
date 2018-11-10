namespace Polling.Unit.Service.DataTransmittingObject
{
    public class UserDTO
    {
        public string message { get; set; }
        public string url { get; set; }
        public string userName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (!(obj is UserDTO)) {
                return false;
            }
            UserDTO dto = (UserDTO) obj;
            return message == dto.message &&
                   url == dto.url && userName == dto.userName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
