using Coink.Application.Interfaces.Services;
using Coink.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coink.Presentation.Controllers;

/// <summary>
/// Principal auth controller
/// </summary>
/// <remarks>
/// Constructor method
/// </remarks>
/// <param name="authService"></param>
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// Generate JWT token access
    /// </summary>
    /// <param name="credentials"></param>
    /// <returns>Jwt Token Security</returns>
    /// <remarks>POST: api/Auth/IssueToken</remarks>
    /// <response code="200"><strong>Success</strong><br/>
    /// <ul>
    ///     <li><b>message:</b> Descripcion de la solicitud realizada.</li>
    ///     <li><b>result:</b> Indice de resultados.
    ///         <ul>
    ///             <li>Success => 0</li>
    ///             <li>Error => 1</li>
    ///             <li>NoRecords => 2</li>
    ///             <li>IsNotActive => 3</li>
    ///             <li>InvalidPassword => 4</li>
    ///         </ul>
    ///     </li>
    ///     <li><b>resultAsString:</b> Descripcion del valor de <i>result.</i></li>
    ///     <li><b>token:</b> Jwt en base64</li>
    /// </ul>
    /// </response>
    /// <response code="400"><strong>BadRequest</strong></response>
    /// <response code="500"><strong>InternalError</strong></response>
    [ProducesResponseType(typeof(TokenOut), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
    [HttpPost("IssueToken")]
    public async Task<IActionResult> IssueToken([FromBody] TokenIn credentials)
    {
        try
        {
            TokenOut token = await _authService.ValidateUser(credentials);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"El usuario no existe, {ex.Message}" });
        }
    }
}
