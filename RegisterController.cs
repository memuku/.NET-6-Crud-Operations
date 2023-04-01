using Dot6.MongoDb.API.CRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RegisterController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Register işlemleri
            var user = await _userService.Register(model);
            return Created("", user);
        }
    }
}
