using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConsoleApp7;

public class Car
{
    public string connectionstring = "Server=myServerAddress;Database=myDataBase;Integrated Security=True";
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public void AddCar(Car car)
    {
        using (IDbConnection db = new SqlConnection(connectionstring))
        {
            string query = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price)";
            db.Execute(query, car);
        }
        
    }
    
    public void UpdateCarPrice(int carId, decimal newPrice)
    {
        using (IDbConnection db = new SqlConnection(connectionstring))
        {
            string query = "UPDATE Cars SET Price = @NewPrice WHERE Id = @CarId";
            db.Execute(query, new { NewPrice = newPrice, CarId = carId });
        }
    }
    
    public void DeleteCar(int carId)
    {
        using (IDbConnection db = new SqlConnection(connectionstring))
        {
            string query = "DELETE FROM Cars WHERE Id = @CarId";
            db.Execute(query, new { CarId = carId });
        }
    }
    
    public List<Car> GetAllCars()
    {
        using (IDbConnection db = new SqlConnection(connectionstring))
        {
            string query = "SELECT * FROM Cars";
            return db.Query<Car>(query).AsList();
        }
    }
    
    public List<Car> GetCarsByBrand(string brandName)
    {
        using (IDbConnection db = new SqlConnection(connectionstring))
        {
            string query = "SELECT * FROM Cars WHERE Brand = @BrandName";
            return db.Query<Car>(query, new { BrandName = brandName }).AsList();
        }
    }
}