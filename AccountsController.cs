using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AccountsController> _logger;


        public AccountsController(UniversityDBContext context, JwtSettings jwtSettings, ILogger<AccountsController> logger)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _logger = logger;
        }

        //Example users
        //TODO: Change by real users in DB
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "nachocamposmarti@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "pepe@gmail.com",
                Name = "User1",
                Password = "pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                //TODO:
                //Search a user in context using Linq
                var searchUser = (from user in _context.Users
                                 where user.Name == userLogin.UserName && user.Password == userLogin.Password
                                 select user).FirstOrDefault();

                Console.WriteLine("User found: ", searchUser);

                //TODO: Change to searchUser
                //var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (searchUser != null)
                {
                    //var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            _logger.LogTrace($"{nameof(AccountsController)} - {nameof(GetUserList)} - Trace Level Log");
            _logger.LogDebug($"{nameof(AccountsController)} - {nameof(GetUserList)} - Debug Level Log");
            _logger.LogInformation($"{nameof(AccountsController)} - {nameof(GetUserList)} - Information Level Log");
            _logger.LogWarning($"{nameof(AccountsController)} - {nameof(GetUserList)} - Warning Level Log");
            _logger.LogError($"{nameof(AccountsController)} - {nameof(GetUserList)} - Error Level Log");
            _logger.LogCritical($"{nameof(AccountsController)} - {nameof(GetUserList)} - Critical Level Log");
            return Ok(Logins);
        }
    }
}
