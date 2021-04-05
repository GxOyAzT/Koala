using Koala.Api.Identity.DataAccess;
using Koala.Api.Identity.DataAccess.Models;
using Koala.Api.Identity.Services;
using Koala.Entities.DataTransfer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koala.Api.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IPasswordGenerator _passwordGenerator;

        public RegisterController(
            UserManager<AppUserModel> userManager,
            IPasswordGenerator passwordGenerator,
            UserDbContext userDbContext)
        {
            _userManager = userManager;
            _passwordGenerator = passwordGenerator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateNewUser(RegisterDTO registerDTO)
        {
            if (registerDTO.Email == null || 
                registerDTO.SchoolId == null || 
                registerDTO.UserId == null || 
                registerDTO.UserRoleEnum == 0)
            {
                return UnprocessableEntity("Incorrect data.");
            }

            var userEmail = _userManager.Users.FirstOrDefault(e => e.Email == registerDTO.Email);

            if (userEmail != null)
            {
                return UnprocessableEntity($"User email {registerDTO.Email} already exists.");
            }

            var userIdSchoolRole = _userManager.Users.FirstOrDefault(e => e.SchoolId == registerDTO.SchoolId &&
                                                                          e.UserId == registerDTO.UserId &&
                                                                          e.UserRoleEnum == registerDTO.UserRoleEnum);

            if (userIdSchoolRole != null)
            {
                return UnprocessableEntity($"User already has account.");
            }

            if (userEmail != null)
            {
                return UnprocessableEntity($"User email {registerDTO.Email} already exists.");
            }

            var password = _passwordGenerator.GenerateRandPass();

            var appUser = new AppUserModel
            {
                Email = registerDTO.Email,
                UserId = registerDTO.UserId,
                SchoolId = registerDTO.SchoolId,
                UserRoleEnum = registerDTO.UserRoleEnum,
                UserName = registerDTO.Email
            };

            var response = await _userManager.CreateAsync(appUser, password);

            if (response.Succeeded)
            {
                registerDTO.TmpPassword = password;
                return Ok(registerDTO);
            }

            return BadRequest(response.Errors);
        }
    }
}
