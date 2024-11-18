namespace Coink.Domain.Entities.Controllers;

public class User
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int City_id { get; set; }
}