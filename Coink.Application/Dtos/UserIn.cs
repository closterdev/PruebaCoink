namespace Coink.Application.Dtos;

public class UserIn
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int City_id { get; set; }
}