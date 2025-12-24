using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperDemo;

public sealed class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public DateTime CreatedAt { get; init; }
}

internal static class Program
{
    private const string ConnectionString =
        "Server=(localdb)\\MSSQLLocalDB;Database=DapperDemoDb;Trusted_Connection=True;TrustServerCertificate=True;";

    private static void Main()
    {
        const string sql = """
            SELECT Id, Name, Price, CreatedAt
            FROM Products
            ORDER BY Id;
            """;

        using var connection = new SqlConnection(ConnectionString);
        IEnumerable<Product> products = connection.Query<Product>(sql);

        foreach (Product product in products)
        {
            Console.WriteLine(
                $"#{product.Id} {product.Name} - {product.Price:C} (Created {product.CreatedAt:yyyy-MM-dd})");
        }
    }
}
