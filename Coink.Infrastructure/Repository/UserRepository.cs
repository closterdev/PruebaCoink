using Coink.Application.Interfaces.Repository;
using Coink.Domain.Entities.Controllers;
using Coink.Cross.Security.Databases;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Coink.Infrastructure.Repository;

public class UserRepository(IOptions<DbCredentials> connection) : IUserRepository
{
    private readonly DbCredentials _connection = connection.Value;

    public async Task<bool> InsertUser(User User)
    {
        using var connection = new NpgsqlConnection(_connection.PostgreSql);
        var command = new NpgsqlCommand("CALL sp_insert_user(@name, @phone, @address, @city_id)", connection);
        command.Parameters.AddWithValue("name", User.Name);
        command.Parameters.AddWithValue("phone", User.Phone);
        command.Parameters.AddWithValue("address", User.Address);
        command.Parameters.AddWithValue("city_id", User.City_id);

        await connection.OpenAsync();
        return await command.ExecuteNonQueryAsync() > 0;
    }
}