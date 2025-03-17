namespace Finalka;

using System.ComponentModel.DataAnnotations;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public int Price { get; set; }
}
