using Coink.Application.Interfaces.Repository;
using Coink.Domain.Entities.Security.Token;
using Coink.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Coink.Infrastructure.Repository;

public class TokenUserRepository(ApiDbContext context) : IAuthRepository
{
    private readonly ApiDbContext _context = context;

    public async Task<TokenUser?> GetUserByKeyAsync(TokenUser userCredentials)
    {
        return await _context.TokenUser
            .AsNoTracking()
            .Where(u => u.Username == userCredentials.Username)
            .FirstOrDefaultAsync();
    }

    //public async Task AddUserAsync(TokenUser user)
    //{
    //    await _context.TokenUser.AddAsync(user);
    //    await _context.SaveChangesAsync();
    //}
}