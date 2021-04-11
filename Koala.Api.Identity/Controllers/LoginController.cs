using Koala.Api.Identity.DataAccess.Models;
using Koala.Api.Identity.Services;
using Koala.Entities.DataTransfer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Koala.Api.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginController(
            UserManager<AppUserModel> userManager,
            ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (loginDTO.Email == null ||
                loginDTO.Password == null)
            {
                return NotFound($"Input Data incorrect format");
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                return NotFound($"Cannot find user of email {loginDTO.Email}");
            }

            if(!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return NotFound($"Incorrect password");
            }

            loginDTO.Token = _tokenGenerator.GenerateToken(user.UserId, user.Id, user.SchoolId, user.UserRoleEnum);

            return Ok(loginDTO);
        }
    }
}
