namespace Finalka;

using Microsoft.EntityFrameworkCore;

public class ServiceMethods
{
    private readonly ShowroomDbContext _context;

    public ServiceMethods(ShowroomDbContext context)
    {
        _context = context;
    }

    public void RegisterClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void AddCarToClient(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
    }

    public void CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void AddServicesToOrder(OrderService orderService)
    {
        _context.OrderServices.Add(orderService);
        _context.SaveChanges();
    }

    public int CalculateOrderTotal(int orderId)
    {
        var orderServices = _context.OrderServices
            .Where(os => os.OrderId == orderId)
            .ToList();

        int totalCost = 0;
        for (int i = 0; i < orderServices.Count; i++)
        {
            totalCost = orderServices[i].TotalPrice + totalCost;
        }
        return totalCost;
    }

    public List<Order> GetOrderHistory(int clientId)
    {
        return _context.Orders
            .Where(o => o.ClientId == clientId)
            .Include(o => o.Car)
            .Include(o => o.OrderServices)
            .ThenInclude(os => os.Service)
            .ToList();
    }
}

