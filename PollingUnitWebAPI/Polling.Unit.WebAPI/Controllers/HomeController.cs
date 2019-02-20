using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Polling.Unit.Service;
using Polling.Unit.Service.DataTransmittingObject;
using Polling.Unit.Service.UserService.Interface;
using Polling.Unit.WebAPI.Data;

namespace Polling.Unit.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class HomeController : Controller
    {
        //private UserManager<ApplicationUser> _userManager;

        private IUserService _service { get; }

        private ApplicationDbContext _context { get; }

        public HomeController(IUserService service,
            ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        [ActionName("createAccount")]
        public IActionResult CreateUser([FromBody] UserConfiguration userConfiguration)
        {
            string userId = userConfiguration.UserId;
            string password = userConfiguration.Password;
            UserDTO userDto = _service.CreateAccount(userId, password);
            string serializedObject = JsonConvert.SerializeObject(userDto);
            return StatusCode(302, Json(serializedObject));
        }

        [HttpPost]
        [ActionName("loginAccount")]
        public async Task<IActionResult> LoginUser([FromBody] UserConfiguration userConfiguration)
        {
            var user = await _context.USER_INFO.FindAsync(userConfiguration.UserId);
            if (user != null && user.PASSWORD == userConfiguration.Password)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, userConfiguration.UserId),
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(2),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                 );
                
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
                //string userId = userConfiguration.UserId;
                //string password = userConfiguration.Password;
                //UserDTO userDto = _service.LoginAccount(userId, password);
                //string serializedObject = JsonConvert.SerializeObject(userDto);
                //return StatusCode(302, Json(serializedObject));
            }
            return Unauthorized();
        }
    }
}
 