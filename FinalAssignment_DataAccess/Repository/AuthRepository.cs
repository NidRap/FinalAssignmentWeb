using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using FinalAssignment_Model.Models.ModelDTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FinalAssignment_DataAccess.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _db;
        public string secretKey;
        public AuthRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<String>("ApiSettings:Secret");



        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.User.FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            var user = _db.User.FirstOrDefault(x => x.Name.ToLower() == loginRequestDto.Name.ToLower() &&
             x.Password == loginRequestDto.Password);
            if (user == null)
            {


                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            LoginResponseDTO loginResponseDto = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };



            return loginResponseDto;
        }

        public async Task<User> Register(RegistrationRequestDTO registrationRequestDto)
        {
            User user = new()
            {
                Name = registrationRequestDto.Name,
                Email = registrationRequestDto.Name,
                Password = registrationRequestDto.Password,
                Role = registrationRequestDto.Role
            };

            _db.User.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}