using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polling.Unit.Service;
using Polling.Unit.Service.DataTransmittingObject;
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
            UserDTO userDto = _service.CreateAccount(userId, password);
            string serializedObject = JsonConvert.SerializeObject(userDto);
            return StatusCode(302, Json(serializedObject));
        }

        [HttpPost]
        [ActionName("loginAccount")]
        public IActionResult LoginUser([FromBody] UserConfiguration userConfiguration)
        {
            string userId = userConfiguration.UserId;
            string password = userConfiguration.Password;
            UserDTO userDto = _service.LoginAccount(userId, password);
            string serializedObject = JsonConvert.SerializeObject(userDto);
            return StatusCode(302, Json(serializedObject));
        }
    }
}
