namespace ConsoleApp4;
using System.Text.Json; 
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

public class Car
{
    
    private string connection_str = JsonSerializer.Deserialize<string>(File.ReadAllText("ConnectionString.json"));
    
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public void InsertCar(Car car)
    {
            using var connection = new SqlConnection(connection_str);
            connection.Open();
            string query = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price)";
            connection.Execute(query, car);
    }

    public void DelteCarAndItsOwner(Car car)
    {
        using var connection = new SqlConnection(connection_str);
        connection.Open();
        string query = "DELETE FROM Owners WHERE CarId = @Car_Id;DELETE FROM Cars WHERE Id = @Car_Id";
        connection.Execute(query, new{ Car_Id = car.Id});
    }
    
    
}