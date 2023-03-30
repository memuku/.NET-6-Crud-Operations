using Dot6.MongoDb.API.CRUD.Collections;
using Dot6.MongoDb.API.CRUD.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.MongoDb.API.CRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IAvukatRepository _iavukatrepository;
    public UserController(IAvukatRepository iavukatrepository)
    {
        _iavukatrepository = iavukatrepository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _iavukatrepository.GetAllAsync();
        return Ok(user);//direk user dönücek ? bakalım buraya 
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _iavukatrepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _iavukatrepository.CreateNewPeopleAsync(newUser);
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }
    [HttpPut]
    public async Task<IActionResult> Put(User updateUser)
    {
        var user = await _iavukatrepository.GetByIdAsync(updateUser.Id);
        if (user == null)
        {
            return NotFound();
        }

        await _iavukatrepository.UpdateUserAsync(updateUser);
        return NoContent();
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var people = await _iavukatrepository.GetByIdAsync(id);
        if (people == null)
        {
            return NotFound();
        }

        await _iavukatrepository.DeleteUserAsync(id);
        return NoContent();
    }
}
