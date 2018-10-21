using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Polling.Unit.Repository.UserDataRepository.Interface;
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
    }
}
