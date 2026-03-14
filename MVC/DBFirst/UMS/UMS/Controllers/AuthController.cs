using Microsoft.AspNetCore.Mvc;
using UMS.Services;
using UMS.DTO;
using NLog;

namespace UMS.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {

            if (request.Username == "admin" && request.Password == "123")
            {
                var token = _tokenService.GenerateToken(request.Username);
                logger.Info("LogIn SuccessFully");


                return Ok(new LoginResponse { Token = token });
            }

            return Unauthorized();
        }
    }
}
