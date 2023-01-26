using Microsoft.EntityFrameworkCore;
using User.Model;

namespace User.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}
