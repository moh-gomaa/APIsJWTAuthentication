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

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultMsg = await _service.AddRoleAsync(model);

            return string.IsNullOrEmpty(resultMsg) ? Ok() : BadRequest(resultMsg);
        }
    }
}
