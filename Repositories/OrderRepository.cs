
using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp1.Repositories;

public class OrderRepository
{
    private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=SandroProjectForUniversity;Trusted_Connection=True;";

    public async Task<int> AddOrderAsync(string orderName, int quantity, int customerId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            using var command = new SqlCommand("AddOrder", connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@OrderName", SqlDbType.NVarChar) { Value = orderName });
            command.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity });
            command.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId });

            var outputOrderId = new SqlParameter("@OrderId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputOrderId);

            await command.ExecuteNonQueryAsync();

            transaction.Commit();

            return (int)outputOrderId.Value;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }


    public async Task<bool> UpdateOrderAsync(int orderId, string orderName, int quantity)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            using var command = new SqlCommand("UpdateOrder", connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderId });
            command.Parameters.Add(new SqlParameter("@OrderName", SqlDbType.NVarChar) { Value = orderName });
            command.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity });

            var result = await command.ExecuteScalarAsync();

            transaction.Commit();

            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<bool> DeleteOrderAsync(int orderId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            using var command = new SqlCommand("DeleteOrder", connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderId });

            var result = await command.ExecuteScalarAsync();

            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<DataSet> GetOrdersAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT o.OrderId, o.OrderName, o.Quantity, c.FullName AS CustomerName FROM Orders o JOIN Customers c ON o.CustomerId = c.CustomerId";

        using var adapter = new SqlDataAdapter((SqlCommand)command);

        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

        var dataSet = new DataSet();
        adapter.Fill(dataSet, "Orders");

        return dataSet;
    }
}
