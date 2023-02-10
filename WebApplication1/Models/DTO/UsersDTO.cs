using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class UsersDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string full_name { get; set; }
        public string email { get; set; }
        public string cms_role { get; set; }
        public string password { get; set; }
        public DateTime created_date { get; set; }
    }
}
