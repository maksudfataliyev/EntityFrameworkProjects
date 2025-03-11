using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManager;

public class Car
{
    [Key]
    public int CarId { get; set; }
    
    public int CustomerId { get; set; }  

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string Make { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Model { get; set; }

    [Required] [MaxLength(50)]
    public string Color { get; set; }
}