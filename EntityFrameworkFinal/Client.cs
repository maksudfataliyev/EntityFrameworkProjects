namespace Finalka;

using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = null!;

    public List<Car> Cars { get; set; } = new();
}