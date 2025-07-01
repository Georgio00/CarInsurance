using MongoDB.Driver;
using PolicyManagment.Application;
using PolicyManagment.Domain;

namespace PolicyManagment.Infrastructure;

public class MongoPolicyDataAccess : IPolicyDataAccess
{
    private readonly IMongoCollection<Policy> _collection;


    public MongoPolicyDataAccess(IMongoDatabase database)
    {
        _collection = database.GetCollection<Policy>("Policies");
    }

    public async Task<Policy>GetByIdAsync(string id)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(); //Id==provided id
    }

    public async Task<List<Policy>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();//return all documents from the policies 

    }

    public async Task AddAsync(Policy policy) 
    {
        await _collection.InsertOneAsync(policy);
    }

    public async Task UpdateAsync(Policy policy)
    {
        await _collection.ReplaceOneAsync(p => p.Id == policy.Id, policy); //replace the existing document where Id matches
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(p => p.Id == id);//delete a policy by its ID
    }

}



