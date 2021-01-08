using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiItau.Business.Interfaces;
using ApiItau.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiItau.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ApiController
    {
        private readonly IPasswordService _loginService;

        public LoginController(IPasswordService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("validar-senha")]
        public ActionResult ValidarSenha([FromBody] string password)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) 
                : CustomResponse(_loginService.ValidatePassword(password));
        }
    }
}
