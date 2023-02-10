using WebApplication1.Models;

namespace WebApplication1.Models.DTO
{
    public class LoginResponseDTO
    {
        public LocalUser user { get; set; }
        public string token { get; set; }
    }
}
