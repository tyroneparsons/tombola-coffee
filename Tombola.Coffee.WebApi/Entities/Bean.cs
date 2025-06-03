using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tombola.Coffee.WebApi.Entities;

public class Bean
{
    [Key] [MaxLength(32)] public required string Id { get; set; }
    [Required] [MaxLength(255)] public required string Name { get; set; }
    [Required] [MaxLength(512)] public required string Description { get; set; }
    [Required] public decimal Cost { get; set; }
    [Required] [MaxLength(255)] public required string Colour { get; set; }
    [Required] [MaxLength(255)] public required string Country { get; set; }
    [Required] [MaxLength(255)] public required string Image { get; set; }
}

public class BeanOfTheDay
{
    [Key] [Required] public Guid Id { get; set; }
    [Required] public DateOnly Date { get; set; }
    [Required] [MaxLength(32)] public required string BeanId { get; set; }
    [ForeignKey(nameof(BeanId))] public required Bean Bean { get; set; }
}