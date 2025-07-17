using MongoDB.Driver;
using ClaimManagement.Application;
using ClaimManagement.Domain;

namespace ClaimManagement.Infrastructure;

public class MongoClaimDataAccess:IClaimDataAccess
{
    private readonly IMongoCollection<Claim> _collection;

    public MongoClaimDataAccess(IMongoDatabase database)
    {
        _collection=database.GetCollection<Claim>("Claims");
    }

    public async Task<Claim>GetByIdAsync(string id)
    {
        return await _collection.Find(c=> c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Claim>>GetByPolicyIdAsync(string PolicyId)
    {
        return await _collection.Find(c=>c.PolicyId == PolicyId).ToListAsync();
    }

    public async Task AddAsync(Claim claim)
    {
        await _collection.InsertOneAsync(claim);
    }

public async Task UpdateAsync(Claim claim)
    {
        await _collection.ReplaceOneAsync(c => c.Id == claim.Id, claim);
    }
}
