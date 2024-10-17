using Domain.Entities;
using MongoDB.Driver;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;

namespace ShopManagementService.Infrastructure.Persistence.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private readonly IMongoCollection<Category> _categories;
    
    public CategoryRepository(IMongoClient client)
    {
        IMongoDatabase database = client.GetDatabase("ShopManagementDB");
        _categories = database.GetCollection<Category>("categories");
    }
    
    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _categories.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);

    public async Task<Category> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _categories.Find(c => c.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Category> AddAsync(Category entity, CancellationToken cancellationToken = default)
    {
        await _categories.InsertOneAsync(entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<bool> UpdateAsync(Category entity, CancellationToken cancellationToken = default)
    {
        var updateResult = await _categories.ReplaceOneAsync(c => c.Id == entity.Id, entity, cancellationToken: cancellationToken);
        return updateResult.IsAcknowledged;
    }

    public async Task<bool> DeleteAsync(string entity, CancellationToken cancellationToken = default)
    {
        var deleteResult = await _categories.DeleteOneAsync(c => c.Id == entity, cancellationToken: cancellationToken);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}