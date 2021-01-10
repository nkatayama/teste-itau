using ApiItau.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiItau.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ApiController
    {
        private readonly IPasswordService _loginService;

        public LoginController(IPasswordService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("password-check")]
        public ActionResult ValidatePassword([FromHeader] string password)
        {
            return string.IsNullOrEmpty(password) ? CustomResponse(new {isValid = false}) 
                : CustomResponse(new {isValid = _loginService.ValidatePassword(password).IsValid});
        }
    }
}
