using Microsoft.AspNetCore.Mvc;
using WebApplication9.Exceptions;
using WebApplication9.Helpers;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet(Name = "FindUser")]
        public ActionResult<ApiResponse<string>> FindUser(string user)
        {
            string[] usersList = new string[] { "John", "Alex", "Altnas", "Elisa", "Bob" };

            if (usersList.Contains(user))
            {
                return new ApiResponse<string> { Success = true, Message = "User Found!", Data = $"Hello {user}" };
            }
            else
            {
                throw new NotFoundException("User not found");
            }
        }
    }
}
