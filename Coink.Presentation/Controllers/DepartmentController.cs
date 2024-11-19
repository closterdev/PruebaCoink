﻿using Microsoft.AspNetCore.Mvc;

namespace Coink.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    // GET: api/<DepartmentController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<DepartmentController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<DepartmentController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<DepartmentController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<DepartmentController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}