using Koala.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Koala.Api.Identity.DataAccess.Models
{
    public class AppUserModel : IdentityUser
    {
        public string SchoolId { get; set; }
        public UserRoleEnum UserRoleEnum { get; set; }
        public string UserId { get; set; }
    }
}
