using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUsersRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            User user = await _userRepository.GetUserByUsernameAsync(username);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> RegisterUserAsync(string username, string password)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception($"User with name {existingUser.Username} already exists");
            }

            var passwordHash = CreatePasswordHash(password);
            var user = new User(username, passwordHash);

            var createdUser = await _userRepository.AddUserAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<ClaimsIdentity> Login(string username, string password, string authScheme)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
            {
                return null;
            }

            var claimIdentity = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "User")
               }, authScheme);

            return claimIdentity;
        }

        private string CreatePasswordHash(string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPasswordHash(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
