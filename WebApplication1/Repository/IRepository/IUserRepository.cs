using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        
        Task<LoginResponseDTO>  Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register (RegisterationRequestDTO registerationRequestDTO);
    }
}
