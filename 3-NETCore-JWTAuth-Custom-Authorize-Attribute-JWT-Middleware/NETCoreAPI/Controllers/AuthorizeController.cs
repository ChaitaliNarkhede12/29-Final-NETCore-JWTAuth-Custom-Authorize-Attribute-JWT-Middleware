using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthorizeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(LoginModel loginModel)
        {
            var tokenModel = _loginService.GetTokenModel(loginModel);
            return Ok(tokenModel);
        }
    }
}
