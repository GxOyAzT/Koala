using Koala.Api.Identity.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Koala.Api.Identity.DataAccess
{
    public class UserDbContext : IdentityDbContext<AppUserModel>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}
