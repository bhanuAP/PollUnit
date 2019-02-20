using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polling.Unit.WebAPI.Data;

namespace Polling.Unit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController: Controller
    {
        private ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _context.USER_INFO.Select(user => user.USER_NAME).ToArray();
        }
    }
}
