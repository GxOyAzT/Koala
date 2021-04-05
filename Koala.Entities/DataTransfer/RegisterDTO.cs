using Koala.Entities.Enums;

namespace Koala.Entities.DataTransfer
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string SchoolId { get; set; }
        public UserRoleEnum UserRoleEnum { get; set; }
        public string UserId { get; set; }
        public string TmpPassword { get; set; }
    }
}
