using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_products.Models;
using project_products.Repositories.Interface;
using project_products.Services;
using project_products.Services.Interface;

namespace project_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        IUserRepository _userRepository;
        ITokenService _tokenService;


        public LoginController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticationAsync([FromBody] User user)
        {
            User userReturn = await _userRepository.GetUser(user.Username, user.Password);
       
            if (userReturn == null)
            {
                return NotFound(new { message = "usuario invalido" });
            }

            var token = _tokenService.GetToken(userReturn);

            return new
            {
                user = userReturn,
                token = token
            };

        }
    }
}
