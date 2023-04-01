using Dot6.MongoDb.API.CRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dot6.MongoDb.API.CRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // Login işlemleri
        var user = await _userService.Login(model);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }
}

