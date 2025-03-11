namespace ShowroomManager;

public class ServiceHistory
{
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}