namespace ConsoleApp4;
using System.Text.Json; 
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class Owner
{
    private string connection_str = JsonSerializer.Deserialize<string>(File.ReadAllText("ConnectionString.json"));
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int CarId { get; set; }

    public void InsertOwner(Owner owner)
    {
        using var connection = new SqlConnection(connection_str);
        connection.Open();
        string query = "INSERT INTO Owners (Name, CarId) VALUES (@NewName, @Car_ID)";
        connection.Execute(query, new { NewName = owner.Name, Car_ID = owner.CarId });
    }

    public void UpdateName(Owner owner)
    {
        using var connection = new SqlConnection(connection_str);
        connection.Open();
        string query = "UPDATE Owners SET Name = @Name WHERE Car_Id = @CarId";
        connection.Execute(query, new {Name = owner.Name, Car_Id = owner.CarId});
    }

    public List<CarAndOwner> GetAllOwners()
    {
        using var connection = new SqlConnection(connection_str);
        connection.Open();
        string query = "SELECT c.Id, c.Brand, c.Model, c.Year, c.Price, o.Name AS OwnerName FROM Cars c INNER JOIN Owners o ON c.Id = o.CarId";
        List<CarAndOwner> owners = connection.Query<CarAndOwner>(query).ToList();
        return owners;
    }

    public List<Car> GetAllCars(Owner owner)
    {
        using var connection = new SqlConnection(connection_str);
        connection.Open();
        string query =
            "SELECT c.Id, c.Brand, c.Model, c.Year, c.Price  FROM Cars c INNER JOIN Owners o ON c.Id = o.CarId WHERE o.Name = @OwnersName";
        List<Car> cars = connection.Query<Car>(query, new{OwnersName = owner.Name}).ToList();
        return cars;
    }
    
}