using Domain.Entities;
using MongoDB.Driver;
using ShopManagementService.Application.Common.Dtos;
using ShopManagementService.Application.Common.Interfaces.Auth;

namespace ShopManagementService.Infrastructure.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly IMongoCollection<ApplicationUser> _users;

    public UserRepository(IMongoClient client)
    {
        IMongoDatabase database = client.GetDatabase("ShopManagementDB");
        _users = database.GetCollection<ApplicationUser>("users");
    }

    public async Task<ApplicationUser> RegisterUserAsync(ApplicationUser registerUser, CancellationToken cancellationToken = default)
    {
        await _users.InsertOneAsync(registerUser, cancellationToken: cancellationToken);
        return registerUser;
    }

    public async Task<ApplicationUser> FindUserByEmail(string Email, CancellationToken cancellationToken = default)
        => await _users.Find(p => p.Email == Email).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    
}