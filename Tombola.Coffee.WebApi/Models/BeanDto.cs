namespace Tombola.Coffee.WebApi.Models;

public class BeanDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Cost { get; set; }
    public required string Colour { get; set; }
    public required string Country { get; set; }
    public required string Image { get; set; }
}
