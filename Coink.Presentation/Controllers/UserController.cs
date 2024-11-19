using Coink.Application.Dtos;
using Coink.Application.Interfaces.Services;
using Coink.Domain.Entities.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coink.Presentation.Controllers;

/// <summary>
/// Controller by user manage
/// </summary>
/// <param name="userService"></param>
[AllowAnonymous]
[ApiController]
[ApiExplorerSettings(IgnoreApi = false)]
//[Authorize]
[Produces("application/json")]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Get all users items
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    /// <summary>
    /// Add a new user item
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserIn request)
    {
        try
        {
            await _userService.CreateUserAsync(request);
            return Ok("Usuario registrado exitosamente.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ApplicationException ex)
        {
            return StatusCode(500, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocurrió un error inesperado.");
        }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}