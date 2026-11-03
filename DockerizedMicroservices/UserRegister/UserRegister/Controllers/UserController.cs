using Microsoft.AspNetCore.Mvc;
using UserRegister.Model;

namespace UserRegister.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        public static List<User> users = new(); 


        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            user.Id = users.Count + 1;

            users.Add(user);

            return Ok(new
            {
                Message = "User registered successfully",
                User = user
            });
        } 


        public IActionResult GetUsers()
        {
            return Ok(users);
        }


    }
}
