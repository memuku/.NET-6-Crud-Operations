using Dot6.MongoDb.API.CRUD.Collections;
namespace Dot6.MongoDb.API.CRUD.Repository;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(string id);
    Task CreateNewUserAsync(User newUser);
    Task UpdateUserAsync(User userToUpdate);
    Task DeleteUserAsync(string id);
    Task<User> Login(LoginModel model);
    Task<User> Register(RegisterModel model);
}
