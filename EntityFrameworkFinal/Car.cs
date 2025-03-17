namespace Finalka;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Brand { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Model { get; set; } = null!;

    [Required]
    public int Year { get; set; }

    [Required]
    public int ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; } = null!;
}