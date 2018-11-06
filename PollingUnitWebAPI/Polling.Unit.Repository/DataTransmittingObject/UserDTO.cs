namespace Polling.Unit.Repository.DataTransmittingObject
{
    public class UserDTO
    {
        public string userName { get; set; }
        public bool hasAccount { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
