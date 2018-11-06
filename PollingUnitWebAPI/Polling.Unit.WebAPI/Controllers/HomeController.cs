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
            var relustDTO = _service.CreateAccount(userConfiguration.ID, userConfiguration.Password);
            return Ok(relustDTO);
        }
    }
}
