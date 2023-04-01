using Dot6.MongoDb.API.CRUD.Collections;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Xml.Linq;

namespace Dot6.MongoDb.API.CRUD.Repository;

public class UserService:IUserService
{
    

    private readonly IMongoCollection<User> _userCollection;

    public UserService(IMongoDatabase mongoDatabase)
    {
       
        _userCollection = mongoDatabase.GetCollection<User>("user");
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
   

    public async Task CreateNewUserAsync(User newUser)
    {
        await _userCollection.InsertOneAsync(newUser);
    }
    public async Task UpdateUserAsync(User UserToUpdate)
    {
        await _userCollection.ReplaceOneAsync(x => x.Id == UserToUpdate.Id, UserToUpdate);
    }
    public async Task DeleteUserAsync(string id)
    {
        await _userCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<User> GetByIdAsync(string id)
    {
        return await _userCollection.Find(x => x.Id == id ).FirstOrDefaultAsync();
    }

    
        
    
    public async Task<User> Login(LoginModel model)
    {
        var user = await _userCollection.Find(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefaultAsync();
        return user;
    }

    public async Task<User> Register(RegisterModel model)
    {
        var user = new User { Email = model.Email, Password = model.Password };
        await _userCollection.InsertOneAsync(user);
        return user;
    }






}

