using Microsoft.AspNetCore.Mvc;
using HollywoodService;
using Models;
using HollywoodService.Interface;
using System.Data;

namespace HollywoodAPI.Controllers
{
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<bool>> AddUser([FromBody] AddUser user)
        {
            bool isAdded = false;
            try
            {
                isAdded = await _userService.AddUser(user);
                return Ok(isAdded);
            }
            catch (Exception)
            {
                return BadRequest(isAdded);
            }
        }
        [HttpPost("Signin")]
        public async Task<ActionResult<User>> Signin(string email, string password)
        {
            User user = new User();
            try
            {
                user = await _userService.GetUserByEmailAndPassword(email, password);
                if(user != null)
                {
                    JwtService jwt = new JwtService(_configuration["Jwt:Key"]!, _configuration["Jwt:Issuer"]!, _configuration["Jwt:Audience"]!);
                    var token = jwt.GenerateToken(email, user.Role);
                    user.Token = token;
                    return Ok(user);
                }
                return NotFound(user);
            }
            catch (Exception)
            {
                return BadRequest(user);
            }
        }
    }
}
