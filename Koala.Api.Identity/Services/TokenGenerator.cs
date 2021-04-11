using Koala.Entities.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Koala.Api.Identity.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userId, string identityId, string schoolId, UserRoleEnum userRoleEnum)
        {
            var claims = new[]
            {
                new Claim("idenity-id", identityId), // value: User.Id
                new Claim("user-id", userId), // value: User.Id
                new Claim("school-id", schoolId),
                new Claim("user-role", ConvertUserRoleEnumToString(userRoleEnum))
            };

            var secretBytes = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]);

            var key = new SymmetricSecurityKey(secretBytes);

            var algorithm = SecurityAlgorithms.HmacSha256;

            var signCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                _configuration["JwtSettings:Issuer"],
                _configuration["JwtSettings:Audenice"],
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJson;
        }

        private string ConvertUserRoleEnumToString(UserRoleEnum userRoleEnum)
        {
            switch (userRoleEnum)
            {
                case UserRoleEnum.Principal:
                    return "PRINCIPAL";
                case UserRoleEnum.Teacher:
                    return "TEACHER";
                case UserRoleEnum.Student:
                    return "STUDENT";
                default:
                    return "ROLE_ERROR";
            }
        }
    }
}
