using Coink.Application.Interfaces.Repository;
using Coink.Cross.Security.Databases;
using Microsoft.Extensions.Options;
using Npgsql;
using Coink.Application.Dtos;

namespace Coink.Infrastructure.Repository;

public class UserRepository(IOptions<DbCredentials> connection) : IUserRepository
{
    private readonly DbCredentials _connection = connection.Value;

    public async Task AddUser(UserIn User)
    {
        try
        {
            using var connection = new NpgsqlConnection(_connection.PostgreSql);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("CALL sp_insert_user(@name, @phone, @address, @city_id)", connection);
            command.Parameters.AddWithValue("name", User.Name);
            command.Parameters.AddWithValue("phone", User.Phone);
            command.Parameters.AddWithValue("address", User.Address);
            command.Parameters.AddWithValue("city_id", User.City_id);

            await command.ExecuteNonQueryAsync();
        }
        catch (PostgresException ex)
        {
            if (ex.SqlState == "P0001")
            {
                throw new ApplicationException($"Error del SP: {ex.MessageText}");
            }

            throw;
        }
    }
}