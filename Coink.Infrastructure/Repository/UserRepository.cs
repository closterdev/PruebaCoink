using Coink.Application.Interfaces.Repository;
using Coink.Cross.Security.Databases;
using Microsoft.Extensions.Options;
using Npgsql;
using Coink.Application.Dtos;
using Coink.Domain.Entities.Controllers;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.Data;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace Coink.Infrastructure.Repository;

public class UserRepository(IOptions<DbCredentials> connection) : IUserRepository
{
    private readonly DbCredentials _connection = connection.Value;

    public async Task AddUserAsync(UserIn user)
    {
        try
        {
            using var connection = new NpgsqlConnection(_connection.PostgreSql);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("CALL sp_insert_user(@name, @phone, @address, @city_id)", connection);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("phone", user.Phone);
            command.Parameters.AddWithValue("address", user.Address);
            command.Parameters.AddWithValue("city_id", user.City_id);

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

    public async Task<List<User>> GetUsersAsync()
    {
        try
        {
            DataTable dt = new();
            List<User> data = new();

            using var connection = new NpgsqlConnection(_connection.PostgreSql);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("CALL sp_select_users", connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                data.Add(new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Phone = reader.GetString(reader.GetOrdinal("phone")),
                    Address = reader.GetString(reader.GetOrdinal("address")),
                    City_id = reader.GetInt32(reader.GetOrdinal("city_id"))
                });
            }

            return data;
        }
        catch (Exception ex)
        {

            throw new ApplicationException("Error al obtener los usuarios", ex);
        }
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        try
        {
            return new User();
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message, ex);
        }
    }

    public async Task UpdateUserAsync(User user)
    {
        try
        {
            using var connection = new NpgsqlConnection(_connection.PostgreSql);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("CALL sp_update_user(@id, @name, @phone, @address, @city_id)", connection);
            command.Parameters.AddWithValue("id", user.Id);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("phone", user.Phone);
            command.Parameters.AddWithValue("address", user.Address);
            command.Parameters.AddWithValue("city_id", user.City_id);

            await command.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        try
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                using var connection = new NpgsqlConnection(_connection.PostgreSql);
                await connection.OpenAsync();

                var command = new NpgsqlCommand("CALL sp_delete_user(@id)", connection);
                command.Parameters.AddWithValue("id", user.Id);
                
                await command.ExecuteNonQueryAsync();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}