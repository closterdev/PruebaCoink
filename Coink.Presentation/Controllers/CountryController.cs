using Microsoft.AspNetCore.Mvc;

namespace Coink.Presentation.Controllers;

/// <summary>
/// Controller by countries manage
/// </summary>
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Produces("application/json")]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    // GET: api/<CountryController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CountryController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CountryController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CountryController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CountryController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
