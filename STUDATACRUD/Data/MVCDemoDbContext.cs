using Microsoft.EntityFrameworkCore;
using STUDATACRUD.Models.Domain;

namespace STUDATACRUD.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

    }
    
}
