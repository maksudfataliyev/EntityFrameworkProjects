using System.ComponentModel.DataAnnotations;

namespace ShowroomManager;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();
 
}