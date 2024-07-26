using ChallengeSND.api.Controllers;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies;
using ChallengeSND.Business.Servicies.Interfaces;
using ChallengeSND.Data.Responses;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeSND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IAccountService _accountService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthenticationService authenticationService, IAccountService accountService, ILogger<AuthController> logger)
        {
            _authenticationService = authenticationService;
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Business.DTOS.RegisterDTO request)
        {
            CustomResponses.RegistrationResponse response = await _accountService.RegisterAsync(request);
            return response.Flag ? Created() : ValidationProblem(new ValidationProblemDetails { Detail = response.Message});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Business.DTOS.LoginDTO request)
        {
            CustomResponses.LoginResponse response = await _accountService.LoginAsync(request);
            return response.Flag ? Ok(new { Token = response.JWTToken }) : ValidationProblem(new ValidationProblemDetails { Detail = response.Message });
        }
    }
}
