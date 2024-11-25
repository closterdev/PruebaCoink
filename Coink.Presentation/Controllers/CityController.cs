﻿using Microsoft.AspNetCore.Mvc;


namespace Coink.Presentation.Controllers;

/// <summary>
/// Controller by cities manage
/// </summary>
[ApiController()]
[ApiExplorerSettings(IgnoreApi = true)]
[Produces("application/json")]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    // GET: api/<CityController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CityController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CityController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CityController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CityController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
