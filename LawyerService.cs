using AutoMapper;
using Business.Interfaces;
using Data;
using Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Nest;

namespace Business.Services
{
    public class LawyerService:ILawyerService
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly IMapper _mapper;

        

        public LawyerService(IMongoDatabase mongoDatabase, IMapper mapper)
        {
            _userCollection = mongoDatabase.GetCollection<User>("USER");
            _mapper = mapper;
        }

        public async Task AddUser(UserDto newLawyerDto)
        {
            var newUser = _mapper.Map<User>(newLawyerDto);
            await _userCollection.InsertOneAsync(newUser);
        }

        public async Task DelUser(string id)
        {
            await _userCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var userList = await _userCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }

        public async Task<UserDto> GetById1(string id)
        {
            var user = await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task SetUser(UserDto userToUpdateDto)
        {
            var userToUpdate = _mapper.Map<User>(userToUpdateDto);
            await _userCollection.ReplaceOneAsync(x => x.Id == userToUpdate.Id, userToUpdate);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _userCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Login(LoginModel model)
        {
            var user = await _userCollection.Find(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Register1(RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            await _userCollection.InsertOneAsync(user);
            return _mapper.Map<UserDto>(user);
        }



        public async Task AddUser(User newUser)
        {
            await _userCollection.InsertOneAsync(newUser);
        }

        public async Task SetUser(User userToUpdate)
        {
            await _userCollection.ReplaceOneAsync(x => x.Id == userToUpdate.Id, userToUpdate);
        }

        async Task<User> ILawyerService.Login(LoginModel model)
        {
            var filter = Builders<User>.Filter.Where(u => u.FirstName == model.Username && u.Password == model.Password);
            var user = await _userCollection.Find(filter).SingleOrDefaultAsync();

            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password.");

            return user;
        }
        async Task<User> ILawyerService.Register(RegisterModel model)
        {
            var filter = Builders<User>.Filter.Where(u => u.FirstName == model.Username && u.Password == model.Password);
            var user = await _userCollection.Find(filter).FirstOrDefaultAsync();

            return user;
        }



        public async Task<UserDto> GetById(object id)
        {
            ObjectId objectId;
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            var user = await _userCollection.Find(filter).FirstOrDefaultAsync();

            if (user == null)
                throw new ArgumentException($"User with id {id} does not exist.");

            return _mapper.Map<UserDto>(user);
        }




        Task ILawyerService.GetById(string ıd)
        {
            throw new NotImplementedException();
        }

     


        public async Task DeleteUser(User userToDelete,string id)
        {
            await _userCollection.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteUser(User userToDelete)
        {
            throw new NotImplementedException();


        }

        public void DeleteUser(string id)
        {
             _userCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
