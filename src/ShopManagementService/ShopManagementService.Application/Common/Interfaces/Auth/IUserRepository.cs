using Domain.Entities;
using ShopManagementService.Application.Common.Dtos;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Common.Interfaces.Auth;

public interface IUserRepository
{
    Task<ApplicationUser> RegisterUserAsync(ApplicationUser registerUser, CancellationToken cancellationToken = default);
    
    Task<ApplicationUser> FindUserByEmail(string Email, CancellationToken cancellationToken = default);
    
}