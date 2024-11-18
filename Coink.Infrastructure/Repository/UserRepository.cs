using Coink.Application.Interfaces;
using Coink.Domain.Entities;
using Coink.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Coink.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context) => _context = context;

    public async Task<User> GetUserByKeyAsync(User userCredentials)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => u.Username == userCredentials.Username)
            .FirstAsync();
    }
}