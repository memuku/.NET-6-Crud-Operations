using Dot6.MongoDb.API.CRUD.Collections;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace Dot6.MongoDb.API.CRUD.Repository;

public class AvukatRepository:IAvukatRepository
{
    

    private readonly IMongoCollection<User> _userCollection;

    public AvukatRepository(IMongoDatabase mongoDatabase)
    {
       
        _userCollection = mongoDatabase.GetCollection<User>("user");
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
    public async Task<User> GetByIdAsync(string id)
    {
        return await _userCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateNewPeopleAsync(User newUser)
    {
        await _userCollection.InsertOneAsync(newUser);
    }
    public async Task UpdateUserAsync(User peopleToUpdate)
    {
        await _userCollection.ReplaceOneAsync(x => x.Id == peopleToUpdate.Id, peopleToUpdate);
    }
    public async Task DeleteUserAsync(string id)
    {
        await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}