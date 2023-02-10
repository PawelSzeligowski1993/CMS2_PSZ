using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<LocalUser> local_users { get; set; }
        public  DbSet<AdvantagesDTO> advantages { get; set; }
        public  DbSet<Page_SectionsDTO> page_sections { get; set; }
        public  DbSet<ServicesDTO> services { get; set; }
        public  DbSet<UsersDTO> users { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)

        {

        }
    }
}
