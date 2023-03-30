using Dot6.MongoDb.API.CRUD.Collections;
namespace Dot6.MongoDb.API.CRUD.Repository;

public interface IAvukatRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(string id);
    Task CreateNewPeopleAsync(User newUser);
    Task UpdateUserAsync(User userToUpdate);
    Task DeleteUserAsync(string id);

}
