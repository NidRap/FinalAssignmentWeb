using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment_Model.Models;
using FinalAssignment_Model.Models.ModelDTO;

namespace FinalAssignment_DataAccess.Repository.IRepository
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
        Task<User> Register(RegistrationRequestDTO registrationRequestDto);
    }
}
