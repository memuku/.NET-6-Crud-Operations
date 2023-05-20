using Data.Models;
using Data;

namespace Business.Interfaces
{
    public interface ILawService
    {
        

        
        Task AddUser(User newUser);
        Task SetUser(User userToUpdate);
        Task DelUser(string id);
        Task DeleteUser(User userToDelete);
        Task<User> Login(LoginModel model);
        Task<User> Register(RegisterModel model);
       
      
        Task<List<UserDto>> GetAll();
        Task<UserDto> GetById(object id);
        Task AddUser(UserDto newUserDto);
        Task SetUser(UserDto userToUpdate);
        Task<UserDto> Register1(RegisterModel model);
        Task<UserDto> GetUserByEmail(string email);
        Task GetById(string ıd);
        Task<UserDto> GetById1(string id);
    }
}
