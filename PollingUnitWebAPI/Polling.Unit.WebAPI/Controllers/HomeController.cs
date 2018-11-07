using System;
using Microsoft.AspNetCore.Mvc;
using Polling.Unit.Service;
using Polling.Unit.Service.UserService.Interface;

namespace Polling.Unit.WebAPI.Controllers
{
    [Route("/[action]")]
    public class HomeController : Controller
    {
        private IUserService _service { get; }

        public HomeController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [ActionName("createAccount")]
        public IActionResult CreateUser([FromBody] UserConfiguration userConfiguration)
        {
            string userId = userConfiguration.UserId;
            string password = userConfiguration.Password;
            try
            {
                _service.CreateAccount(userId, password);
            }
            catch (Exception e)
            {
                return StatusCode(302, Json(e.Message));
            }

            return Ok();
        }
    }
}
