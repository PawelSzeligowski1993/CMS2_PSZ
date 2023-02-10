using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class Page_SectionsDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public string title { get; set; }
        public string img_url { get; set; }
        public DateTime last_mod_date { get; set; }
        public int last_mod_user_id { get; set; }

        [ForeignKey("advantages")]
        public int Advantages_List_id { get; set; }

        public AdvantagesDTO advantages { get; set; }

        [ForeignKey("users")]
        public int User_id { get; set; }

        public UsersDTO users { get; set; }

        [ForeignKey("Services")]
        public int Service_List_id { get; set; }

        public ServicesDTO services { get; set; }
    }
}
