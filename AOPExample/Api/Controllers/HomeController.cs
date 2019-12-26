using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IUserService _userService;
        public HomeController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public string Get() 
        {
            return _userService.GetUser().Name;
        }
    }
}