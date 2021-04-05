using Koala.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koala.Api.Identity.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(string userId, string identityId, string schoolId, UserRoleEnum userRoleEnum);
    }
}
