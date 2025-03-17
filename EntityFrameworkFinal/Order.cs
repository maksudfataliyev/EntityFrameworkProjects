namespace Finalka;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ClientId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; } = null!;

    [ForeignKey(nameof(CarId))]
    public Car Car { get; set; } = null!;

    public List<OrderService> OrderServices { get; set; } = new();
}