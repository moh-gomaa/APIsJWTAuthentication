using APIsJWTAuthentication.Models;
using APIsJWTAuthentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIsJWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            this._service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.RegisterAsync(model);

            if(!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        
        [HttpPost("getToken")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.GetTokenAsync(model);

            if(!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
