using AutoMapper;
using Business.Interfaces;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace _.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILawService _iuserservice;
        private readonly IMapper _mapper;

        public UserController(ILawService iuserservice, IMapper mapper)
        {
            _iuserservice = iuserservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _iuserservice.GetAll();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(object id)
        {
            var user = await _iuserservice.GetById(id);
            if (user == null)
            {
                return Forbid("Yetki Sahibi Değilsiniz");
            }
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterModel model)
        {
            var newUser = _mapper.Map<User>(model);
            await _iuserservice.AddUser(newUser);
            var userDto = _mapper.Map<UserDto>(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, userDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDto updateUserDto)
        {
            var userToUpdate = await _iuserservice.GetById(updateUserDto);
            if (userToUpdate == null)
            {
                return Unauthorized("Kullanıcı Bilgileri Yanlış Girildi");
            }

            var mappedUser = _mapper.Map<User>(updateUserDto);
            await _iuserservice.SetUser(mappedUser);
            return NoContent();
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, ILawyerService _iuserservice)
        {
            var userToDelete = _iuserservice.GetById(id);
            if (userToDelete == null)
            {
                return Forbid("Yetki Sahibi Değilsiniz");
            }

            _iuserservice.DelUser(id);
            return NoContent();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Login işlemleri
            var user = await _iuserservice.Login(model);
            if (user == null)
            {
                return Unauthorized("Kullanıcı adı veya Şifre Hatalı!");
            }
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var existingUser = await _iuserservice.GetUserByEmail(model.Email);
            if (existingUser != null)
            {
                return Conflict("Bu email adresi zaten kullanımda.");
            }
            // Register işlemleri
            _ = _mapper.Map<User>(model);
            var user = await _iuserservice.Register(model);
            var userDto = _mapper.Map<UserDto>(user);
            return Created("Kayıt Başarılı Şekilde Oluşturuldu", userDto);

        }
    }

}

