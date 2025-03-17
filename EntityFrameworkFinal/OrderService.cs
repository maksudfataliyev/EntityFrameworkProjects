namespace Finalka;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderService
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public int TotalPrice { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    [ForeignKey(nameof(ServiceId))]
    public Service Service { get; set; } = null!;
}