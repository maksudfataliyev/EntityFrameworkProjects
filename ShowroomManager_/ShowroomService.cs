
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ShowroomManager
{
    public class ShowroomService
    {
        private readonly ShowroomContext _context;

        public ShowroomService(ShowroomContext context)
        {
            _context = context;
        }


        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void AddSale(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.Include(c => c.Customer).ToList();
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Include(c => c.Customer).FirstOrDefault(c => c.CarId == carId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void UpdateCar(int carId, Car updatedCar)
        {
            var car = _context.Cars.Find(carId);
            if (car != null)
            {
                car.Make = updatedCar.Make;
                car.Model = updatedCar.Model;
                car.Color = updatedCar.Color;
                _context.SaveChanges();
            }
        }

        public void UpdateCustomer(int customerId, Customer updatedCustomer)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                _context.SaveChanges();
            }
        }

        public void DeleteCar(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
        


        public List<Car> GetCarsByCustomer(int customerId)
        {
            return _context.Cars
                .Where(c => c.CustomerId == customerId)
                .ToList();
        }
        

        public Dictionary<int, int> GetSalesCountByEmployee()
        {
            var salesCount = _context.Sales
                .GroupBy(s => s.EmployeeId)
                .Select(g => new { EmployeeId = g.Key, SalesCount = g.Count() })
                .ToList();

            return salesCount.ToDictionary(x => x.EmployeeId, x => x.SalesCount);
        }


        #region Display Data in Console

        public void DisplayAllCars()
        {
            var cars = GetAllCars();
            foreach (var car in cars)
            {
                Console.WriteLine($"Car Id: {car.CarId}, Make: {car.Make}, Model: {car.Model}, Customer: {car.Customer.FirstName} {car.Customer.LastName}");
            }
        }

        public void DisplayAllCustomers()
        {
            var customers = GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer Id: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
            }
        }

        #endregion
    }
}
