﻿namespace Data.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }

    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Bar { get; set; }
        public string TcNO { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

