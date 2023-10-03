using Ecommerce_server.DTOs;
using Ecommerce_server.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new();
        private readonly IConfiguration _configuration;
        public readonly IUserService _userService;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        //ACTION METHODS
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await _userService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            if (result == null)
                return NotFound("User not Found");

            return result;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            return Ok(await _userService.CreateUser(request));
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var result = await _userService.Login(request);
            if (result is null)
            {
                return NotFound("Login Error");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result is null)
                return NotFound("User not Found");

            return result;
        }
    }
}