using Domain.Entities;
using MongoDB.Driver;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;

namespace ShopManagementService.Infrastructure.Persistence.Repositories;

public class ProductRepository: IRepository<Product>
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository(IMongoClient client)
    {
        IMongoDatabase database = client.GetDatabase("ShopManagementDB");
        _products = database.GetCollection<Product>("products");
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await _products.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);

    public Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => _products.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Product> AddAsync(Product entity, CancellationToken cancellationToken = default)
    {
        await _products.InsertOneAsync(entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<bool> UpdateAsync(Product entity, CancellationToken cancellationToken = default)
    {
        var updateResult = await _products.ReplaceOneAsync(c => c.Id == entity.Id, entity, cancellationToken: cancellationToken);
        return updateResult.IsAcknowledged;
    }

    public async Task<bool> DeleteAsync(string entity, CancellationToken cancellationToken = default)
    {
        var deleteResult = await _products.DeleteOneAsync(c => c.Id == entity, cancellationToken: cancellationToken);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}