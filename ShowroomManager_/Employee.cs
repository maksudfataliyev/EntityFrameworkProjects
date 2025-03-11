using System.ComponentModel.DataAnnotations;

namespace ShowroomManager;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}