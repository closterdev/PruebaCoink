﻿namespace Coink.Domain.Entities.Controllers;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Department_id { get; set; }
}