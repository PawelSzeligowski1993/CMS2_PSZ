using WebApplication1.Models;

namespace WebApplication1.Models.DTO
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
