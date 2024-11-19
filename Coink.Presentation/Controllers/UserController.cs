using Coink.Application.Dtos;
using Coink.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coink.Presentation.Controllers;

/// <summary>
/// Controller by user manage
/// </summary>
/// <param name="userService"></param>
[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    // GET: api/<UserController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<UserController>/5
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
            await _userService.CreateUser(request);
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

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}