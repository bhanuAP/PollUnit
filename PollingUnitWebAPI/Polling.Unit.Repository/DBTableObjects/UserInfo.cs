using System.ComponentModel.DataAnnotations;

namespace Polling.Unit.Repository.DBTableObjects
{
    public class UserInfo
    {
        [Key]
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
    }
}
