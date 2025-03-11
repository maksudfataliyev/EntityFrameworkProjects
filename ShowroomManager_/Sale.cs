using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManager;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    public int EmployeeId { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }  

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }

    [ForeignKey("CarId")]
    public Car Car { get; set; }
}