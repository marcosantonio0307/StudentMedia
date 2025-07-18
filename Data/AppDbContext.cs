using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentMedia.Models;

namespace StudentMedia.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Matter> Matters { get; set; }
        public DbSet<Models.Period> Periods { get; set; }
        public DbSet<Models.Note> Notes { get; set; }
    }
}
